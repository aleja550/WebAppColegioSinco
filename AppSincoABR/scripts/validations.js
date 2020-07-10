function LoginValidate() {
    var usuario, clave;

    usuario = document.getElementById("txtUsuario").value;
    clave = document.getElementById("txtClave").value;

    if (usuario == "" || clave == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }
    return true;
}


function crearuserValidate() {
    var CodCliente, TipoUser, Nombre, Apellido, Usuario, Clave;

    CodCliente = document.getElementById("ContentD_DdlCliente").value;
    TipoUser = document.getElementById("ContentD_DdlUserType").value;
    Nombre = document.getElementById("ContentD_txtNombreUsuario").value;
    Apellido = document.getElementById("ContentD_txtApellido").value;
    Usuario = document.getElementById("ContentD_Usuariotxt").value;
    Clave = document.getElementById("ContentD_Passtxt").value;
    expresionregusuario = /[A-Za-z0-9]$/;

    if (CodCliente == 0 || TipoUser == "Select" || Nombre == "" || Apellido == "" || Usuario == "" || Clave == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }

    else if (Nombre.length > 20 || Apellido.length > 20 || Usuario.length > 20 || Clave.length > 20) {
        alert("Los campos pueden tener hasta 20 carácteres");
        return false;
    }
    else if (!expresionregusuario.test(Usuario.trim())) {
        alert("No se admiten carácteres especiales en el campo Usuario.");
        return false
    }
    return true;

}

function edituserValid() {
    var TipoUser, Nombre, Apellido, Clave;

    TipoUser = document.getElementById("ContentD_DdlUserType").value;
    Nombre = document.getElementById("ContentD_txtNombre").value;
    Apellido = document.getElementById("ContentD_txtApellido").value;
    Clave = document.getElementById("ContentD_txtPass").value;

    if (TipoUser == "Select" || Nombre == "" || Apellido == "" || Clave == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }

    else if (Nombre.length > 20 || Apellido.length > 20 || Clave.length > 20) {
        alert("Los campos solo pueden tener hasta 20 carácteres");
        return false;
    }

    return true;
}





