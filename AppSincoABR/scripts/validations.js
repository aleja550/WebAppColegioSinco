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

function VehiculoValid() {
    var cliente, usuario, imei, placa, marca, color, modelo, cilindraje;

    cliente = parseInt(document.getElementById("ContentD_DdlCliente").value);
    //cliente = parseInt(document.getElementById('<%=DdlCliente.ClientID %>').value);
    usuario = parseInt(document.getElementById("ContentD_DdlUsuario").value);
    imei = parseInt(document.getElementById("ContentD_DdlImei").value);
    placa = document.getElementById("ContentD_Placatxt").value;
    marca = document.getElementById("ContentD_Marcatxt").value;
    color = document.getElementById("ContentD_Colortxt").value;
    modelo = document.getElementById("ContentD_Modelotxt").value;
    cilindraje = document.getElementById("ContentD_Cilindrajetxt").value;
    expresionregplaca = /^[\w]{3}[\d]{3}$/;


    if (cliente === 0 || usuario === 0 || imei === 0 || placa == "" || marca == "" || color == "" || modelo == "" || cilindraje == "" || Clave == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }
    else if (!expresionregplaca.test(placa.trim())) {
        alert("Son 3 letras y 3 numeros");
        return false
    }

    return true;
}

function EditCarValidate() {
    var placa, marca, color, modelo, cilindraje;

    placa = document.getElementById("ContentD_Placatxt").value;
    marca = document.getElementById("ContentD_Marcatxt").value;
    color = document.getElementById("ContentD_Colortxt").value;
    modelo = document.getElementById("ContentD_Modelotxt").value;
    cilindraje = document.getElementById("ContentD_Cilindrajetxt").value;
    expresionregplaca = /^[\w]{3}[\d]{3}$/;

    if (placa == "" || marca == "" || color == "" || modelo == "" || cilindraje == "" || Clave == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }
    else if (!expresionregplaca.test(placa)) {
        alert("Son 3 letras y 3 numeros");
        return false
    }

}

function createClienteValidate() {
    var TipoId, Id, Nombre, Representante, Direccion, Telefono, Correo, expresionCorreo;

    TipoId = document.getElementById("ContentD_DdlID").value;
    Id = document.getElementById("ContentD_idtxt").value;
    Nombre = document.getElementById("ContentD_txtNombre").value;
    Representante = document.getElementById("ContentD_txtRepresentante").value;
    Direccion = document.getElementById("ContentD_txtDireccion").value;
    Telefono = parseInt(document.getElementById("ContentD_txtTel").value);
    Correo = document.getElementById("ContentD_txtCorreo").value;
    expresionCorreo = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (TipoId == "Select" || Id == "" || Nombre == "" || Direccion == "" || Telefono == "" || Correo == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }
    else if (TipoId === "0" && Representante == "") {
        alert("El campo de Representante es obligatorio para Persona Juridica");
        return false;
    }

    else if (TipoId === "1" && isNaN(Id)) {
        alert("La cedula no es válida");
        return false;
    }

    else if (TipoId != "0" || "1" && !expresionCorreo.test(Correo())) {
        alert("El correo no es válido");
        return false;
    }

    else if (isNaN(Telefono)) {
        alert("El telefono no es válido");
        return false;
    }

    return true;
}

function EditClientValidate() {
    var NombreCliente, Representante, Direccion, Telefono, Correo, expresionCorreo;

    NombreCliente = document.getElementById("ContentD_txtCliente").value;
    Representante = document.getElementById("ContentD_txtlegal").value;
    Direccion = document.getElementById("ContentD_txtdire").value;
    Telefono = parseInt(document.getElementById("ContentD_txttelefono").value);
    Correo = document.getElementById("ContentD_txtcorreo").value;
    expresionCorreo = /^([a-z]+[a-z1-9._-]*)@{1}([a-z1-9\.]{2,})\.([a-z]{2,3})$/;

    if (NombreCliente == "" || Representante == "" || Direccion == "" || Telefono == "" || Correo == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }

    else if (isNaN(Telefono.trim)) {
        alert("El telefono no es válido");
        return false;
    }

    else if (!expresionCorreo.test(Correo.trim())) {
        alert("El correo no es válido");
        return false;
    }

    return true;
}

function SimValidate() {
    var Cliente, Telefono, Operador;

    Cliente = document.getElementById("ContentD_DdlCliente").value;
    Telefono = parseInt(document.getElementById("ContentD_txtNumeroSimCard").value);
    Operador = parseInt(document.getElementById("ContentD_DdlSimType").value);

    if (Cliente == 0) {
        alert("El campo Cliente es obligatorio");
        return false;
    }

    else if (isNaN(Telefono)) {
        alert("El número de la simcard no es válido");
        return false;
    }
    else if (Operador == 0) {
        alert("El campo operador es obligotorio");
        return false;
    }

    return true
}

function EditSimValidate() {
    var Telefono, Operador;

    Telefono = parseInt(document.getElementById("ContentD_txtNumeroSimCard").value);
    Operador = parseInt(document.getElementById("ContentD_DdlSimType").value);

    if (Operador == 0) {
        alert("El campo Operador es obligatorio");
        return false;
    }

    else if (isNaN(Telefono)) {
        alert("El número de la simcard no es válido");
        return false;
    }

    return true
}

function CreateGpsValidate() {
    var Cliente, NumeroSim, Imei, Serial;

    Cliente = document.getElementById("ContentD_DdlCliente").value;
    NumeroSim = document.getElementById("ContentD_DdlNumero").value;
    Imei = document.getElementById("ContentD_Imeitxt").value;
    Serial = document.getElementById("ContentD_Serialtxt").value;
    expresionreguserial = /[A-Za-z0-9]$/;

    if (Cliente === 0 || NumeroSim === 0 || Imei == "" || Serial == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }
    else if (isNaN(Imei)) {
        alert("El número del Imei no es válido");
        return false;
    }

    else if (!expresionreguserial.test(Serial.trim())) {
        alert("No se admiten carácteres especiales en el campo Serial.");
        return false
    }
    return true
}

function EditGpsValidate() {
    var Imei, Serial;

    Imei = document.getElementById("ContentD_Imeitxt").value;
    Serial = document.getElementById("ContentD_Serialtxt").value;
    expresionreguserial = /[A-Za-z0-9]$/;

    if (Imei == "" || Serial == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }

    else if (isNaN(Imei)) {
        alert("El número del Imei no es válido");
        return false;
    }

    else if (!expresionreguserial.test(Serial.trim())) {
        alert("No se admiten carácteres especiales en el campo Serial.");
        return false
    }
    return true

}





