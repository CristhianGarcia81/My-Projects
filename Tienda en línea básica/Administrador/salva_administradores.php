<?php
require "./Funciones/conecta.php";
$con = conecta();

$nombre = $_REQUEST['nombre'];
$apellidos = $_REQUEST['apellidos'];
$correo = $_REQUEST['correo'];
$password = $_REQUEST['pasw'];
$rol = $_REQUEST['rol'];

$file_name = $_FILES['archivo']['name'];
$file_tmp = $_FILES['archivo']['tmp_name'];
$cadena = explode(".", $file_name);
$ext = end($cadena);
$dir = "archivos/";
$file_enc = md5_file($file_tmp);


if($file_name != '')
{
	$fileName1 = "$file_enc.$ext";
	copy($file_tmp, $dir.$fileName1);
}

if($password != '')
{
	$password = md5($password);
}

$sql = "INSERT INTO administradores VALUES
		(0,'$nombre', '$apellidos', '$correo', '$password', $rol,
		'$file_name', '$fileName1', 1, 0)";
$res = mysql_query($sql, $con);

header("Location: Tabla administradores.php");

?>