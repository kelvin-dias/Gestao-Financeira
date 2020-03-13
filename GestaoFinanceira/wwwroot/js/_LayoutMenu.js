let app;
class _LayoutMenu{
	constructor(){        
        this.Eventos();
		
	}

	Eventos(){
       //#region - MÉTODOS DO BOTÃO FLUTUANTE
		function toggleFAB(fab){
            if(document.querySelector(fab).classList.contains('show')){
              document.querySelector(fab).classList.remove('show');
          }else{
              document.querySelector(fab).classList.add('show');
          }
        }
        
        document.querySelector('.fab .main').addEventListener('click', function(){
            toggleFAB('.fab');
        });
        
        document.querySelectorAll('.fab ul li button').forEach((item)=>{
            item.addEventListener('click', function(){
                toggleFAB('.fab');
            });
        });
        //#endregion
    
        $("body").on("click","#btnSalvar", ()=>{
            if(this.Validar("modal-receita")){
                // this.GravarReceita();
                $('#modal-popin').modal('hide');
                this.LimparCampos();
            }
        });

        $(document.body).on("click", "#chkRepetir", ()=> $("#chkRepetir").prop("checked") ? $("#txtQtdParcelas").prop("disabled", false) : $("#txtQtdParcelas").prop("disabled", true).val("").trigger("change") );

    }
    
    GravarReceita(){
         let objeto = {
			  Valor: $("#txtValor").val() || null                   
			, Pago: $("#chkPago").prop("checked")
			, ReceitaFixa: $("#chkReceitaFixa").prop("checked")
			, ReceitaParcelada: $("#chkRepetir").prop("checked")
            , QtdParcelas: $("#txtQtdParcelas").val() || null
            , Descricao: $("#txtDescricao").val() || null
            , DhReceita: $("#txtData").val() || null
        }

        $.ajax({
            url: "/Receita/GravarReceita",
            type: "POST",
            data: objeto,
            success: function (result) {
                console.log(result);
            },
            error: function () {
                alert("Oops! Algo deu errado.");
                console.log(result);
            }
        });
        
    }

    /*--- VALIDAÇÃO ---*/
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
                VerificarCampo(!$("#txtDescricao").val(), "Insira uma Descrição para Receita", "#txtDescricao");
                VerificarCampo($("#ddlCategoria").val().length == 0, "Selecione uma Categoria para Receita", "#ddlCategoria");
            break;
        }

        return ok;
    }

    LimparCampos(){
        debugger
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
	app = new _LayoutMenu();
})





