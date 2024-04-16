document.getElementById('formUsuario').onsubmit = function () {
    var contraseña = document.getElementById('Contrase_a').value;
    var confirmarContraseña = document.getElementById('confirmarContraseña').value;
    if (contraseña !== confirmarContraseña) {
        document.getElementById('errorConfirmacion').innerText = "Las contraseñas no coinciden.";
        return false;
    }
    return true;
};