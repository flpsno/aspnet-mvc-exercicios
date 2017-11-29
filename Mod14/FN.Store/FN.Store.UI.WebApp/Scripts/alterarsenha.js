
$("#senhaBtn").click(function () {
    $("#alterarSenhaModal").modal("show");
});

$("#alterarSenhaBtn").click(function () {
    var data = {};
    data.senha = $("#senhaTxt").val();
    $.post(parametrosUrls._urlSenha, data, function (ret) {
        if (ret != null && ret.status) {
            toastr.success(ret.mensagem, "Alterar Senha");
        } else {
            toastr.error(ret.mensagem, "Alterar Senha");
        }
        $("#alterarSenhaModal").modal("hide");
    });
});