<?php
$nombre = $_POST['nombre'];
$apellido = $_POST['apellido'];
$correo = $_POST['correo'];
$mensaje = $_POST['mensaje'];
$success = mail("cristhian.garcia4417@alumnos.udg.mx", "Contacto", $mensaje, "FROM $correo");
header("Location: contacto.php");

?>