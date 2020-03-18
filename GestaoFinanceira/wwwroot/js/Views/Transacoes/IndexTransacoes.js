let app;
class Transacoes{
	constructor(){        
        this.Eventos();
        this.MontarTabela({Tipo: "receita"});
    }

    Eventos(){
        $("body").on("click","#btnReceita, #btnDespesa, #btnMovimentacao", (e)=>{
            let tipo = $(e.currentTarget).data("tipo");
            let objeto = {
                Tipo: tipo
            }
            switch(tipo){
                case "receita":
                    $("#btnTransacoes").removeClass("btn-primary").removeClass("btn-danger");
                    $("#btnTransacoes").addClass("btn-success");
                    $("#btnTransacoes").text("Receitas");
                break;

                case "despesa":
                    $("#btnTransacoes").removeClass("btn-primary").removeClass("btn-success");
                    $("#btnTransacoes").addClass("btn-danger");
                    $("#btnTransacoes").text("Despesas");
                break;

                case "transacoes":
                    $("#btnTransacoes").removeClass("btn-danger").removeClass("btn-success");
                    $("#btnTransacoes").addClass("btn-primary");
                    $("#btnTransacoes").text("Transações");
                break;
            }
            this.MontarTabela(objeto);
        });
    }

    MontarTabela(objeto){
        $.ajax({
            url: "/Transacoes/ObterTransacoes",
            type: "POST",
            data: objeto,
            success: function (result) {
                if (result.includes("[Erro]"))
                    master.ShowMessage(2, result.replace("[Erro]", ""));
                else {
                    let table = result;
                    console.log(result);
                    $("#tblTransacoes").find("tbody").html(`
                    ${
                        table.map(item => {
                        return `<tr>
                            <td >${ app.FormatarDataPadraoBR(item.dataHora)}</td>
                            <td >${ item.descricao}</td>
                            <td >Categoria</td>
                            <td >Conta</td>
                            <td >R$ ${ item.valor}</td>
                        </tr>` }).join("")
                    }
                `);
                    
                }
            },
            error: function () {
                master.ShowMessage(2, "Oops! Algo deu errado.", "")
            }
        });

        
    }

    FormatarDataPadraoBR(data){

        let time = new Date(data.split(".")[0].replace("T", " "));
        let mes = ((time.getMonth()+1) < 10 ? "0" + (time.getMonth()+1) : (time.getMonth()+1));
        let dia = (time.getDate() < 10 ? "0" + time.getDate() : time.getDate());
    
        return dia+"/"+mes+"/"+time.getFullYear();
    }
}
    
$(document).ready(function(){
	app = new Transacoes();
})