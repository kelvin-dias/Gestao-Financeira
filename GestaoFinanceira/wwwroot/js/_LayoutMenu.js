let master;
class _LayoutMenu{
	constructor(){        
        this.Eventos();
	}

	Eventos(){
        $("body").on("click","#btnSalvar", ()=>{
            if(this.Validar("modal-receita")){
                this.GravarReceita();
                $('#modal-popin').modal('hide');
                this.LimparCampos();
            }
        });

        $("body").on("click","#btnSalvarDespesa", ()=>{
            if(this.Validar("modal-despesa")){
                this.GravarDespesa();
                $('#modal-popin-despesa').modal('hide');
                this.LimparCampos();
            }
        });

        $(document.body).on("click", "#chkRepetir", ()=> $("#chkRepetir").prop("checked") ? $("#txtQtdParcelas").prop("disabled", false) : $("#txtQtdParcelas").prop("disabled", true).val("").trigger("change") );

        $("#txtValor, #txtValorDespesa").mask('#.##0,00', {reverse: true});
    }
    
    GravarReceita(){
         let objeto = {
			  Valor: $("#txtValor").val() || null                   
			, Pago: $("#chkPago").prop("checked")
			, ReceitaFixa: $("#chkReceitaFixa").prop("checked")
			, ReceitaParcelada: $("#chkRepetir").prop("checked")
            , QtdParcelas: $("#txtQtdParcelas").val() || null
            , Descricao: $("#txtDescricao").val() || null
            , DataHora: $("#txtData").val() || null
        }

        $.ajax({
            url: "/Receita/GravarReceita",
            type: "POST",
            data: objeto,
            success: function (result) {
                if (result.includes("[Erro]"))
		            master.ShowMessage(2, result.replace("[Erro]", ""));
		        else {
		            master.ShowMessage(1, "Salvo com sucesso","");
		        }
            },
            error: function () {
                master.ShowMessage(2, "Oops! Algo deu errado.", "")
            }
        });
        
    }

    GravarDespesa(){
        let objeto = {
             Valor: $("#txtValorDespesa").val() || null                   
           , Pago: $("#chkPagoDespesa").prop("checked")
           , ReceitaFixa: $("#chkReceitaFixaDespesa").prop("checked")
           , ReceitaParcelada: $("#chkRepetirDespesa").prop("checked")
           , QtdParcelas: $("#txtQtdParcelasDespesa").val() || null
           , Descricao: $("#txtDescricaoDespesa").val() || null
           , DataHora: $("#txtDataDespesa").val() || null
       }

       $.ajax({
           url: "/Despesa/GravarDespesa",
           type: "POST",
           data: objeto,
           success: function (result) {
               if (result.includes("[Erro]"))
                   master.ShowMessage(2, result.replace("[Erro]", ""));
               else {
                master.ShowMessage(1, "Salvo com sucesso","");
               }
           },
           error: function () {
            master.ShowMessage(2, "Oops! Algo deu errado.", "")
           }
       });
       
   }

    Validar(modal){
        let ok = true;
        var VerificarCampo = function (verificar, mensagem, seletor) {
            if (verificar) {
                ok = false;
                $(seletor).closest(".form-group").removeClass("is-invalid").addClass("is-invalid")
                $(seletor).addClass("is-invalid").siblings(".invalid-feedback").text(mensagem).focus();
            } else {
                $(seletor).removeClass("is-invalid");
                $(seletor).closest(".form-group").removeClass("is-invalid");
            }

            return verificar;
        }

        switch(modal){
            case "modal-receita":
                VerificarCampo(!$("#txtValor").val(), "Insira um valor", "#txtValor");
                VerificarCampo(!$("#txtData").val(), "Insira uma Data", "#txtData");
                VerificarCampo(!$("#txtDescricao").val(), "Insira uma Descrição para Receita", "#txtDescricao");
                VerificarCampo($("#ddlCategoria").val() == 0, "Selecione uma Categoria para Receita", "#ddlCategoria");

                if($("#chkRepetir").prop("checked")){
                    VerificarCampo(!$("#txtQtdParcelas").val(), "Insira a quantidade de Parcelas", "#txtQtdParcelas");
                }
            break;

            case "modal-despesa":
                VerificarCampo(!$("#txtValorDespesa").val(), "Insira um valor", "#txtValorDespesa");
                VerificarCampo(!$("#txtDataDespesa").val(), "Insira uma Data", "#txtDataDespesa");
                VerificarCampo(!$("#txtDescricaoDespesa").val(), "Insira uma Descrição para Receita", "#txtDescricaoDespesa");
                VerificarCampo($("#ddlCategoriaDespesa").val() == 0, "Selecione uma Categoria para Receita", "#ddlCategoriaDespesa");

                if($("#chkRepetirDespesa").prop("checked")){
                    VerificarCampo(!$("#txtQtdParcelasDespesa").val(), "Insira a quantidade de Parcelas", "#txtQtdParcelasDespesa");
                }
            break;
        }

        return ok;
    }

    ShowMessage(tipoAlerta, texto, cabecalho){
        // cabecalho e icone
        cabecalho = cabecalho ? cabecalho + "</br>" : "";
        let icone, background;	
    
        switch (tipoAlerta) {
            case 1:
                cabecalho = !cabecalho ? "<i class='fa fa-check'></i> <b>Sucesso</b><br/>" : cabecalho;
                icone = "glyphicon-ok";
                background = "success";
                break;
            case 2:
                cabecalho = !cabecalho ? "<i class='fa fa-times'></i> <b>Erro</b><br/>" : cabecalho;
                icone = "glyphicon-hand-right";
                background = "danger";
                break;
            case 3:
                cabecalho = !cabecalho ? "<i class='fa fa-info'></i> <b>Informação</b><br/>" : cabecalho;
                icone = "glyphicon-info-sign";
                background = "info";
                break;
            case 4:
                cabecalho = !cabecalho ? "<i class='fa fa-warning'></i> <b>Aviso</b><br/>" : cabecalho;
                icone = "glyphicon-record";
                background = "warning";
                break;
        }
    
        $.notify(cabecalho + texto, { type: background, placement: { align: 'right' }, z_index: 5000 });
    }

    LimparCampos(){
        $("#txtValor").val("");    
        $("#chkPago").removeAttr("checked");          
		$("#chkPago").attr("checked", true);
		// $("#chkReceitaFixa").prop("checked");
		// $("#chkRepetir").prop("checked");
        $("#txtQtdParcelas").val("");
        $("#txtDescricao").val("");
        $("#txtData").val("");
    }

    

}	

$(document).ready(function(){
	master = new _LayoutMenu();
})