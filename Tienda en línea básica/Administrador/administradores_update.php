<?php
require "./Funciones/conecta.php";
$con = conecta();

$id = $_REQUEST['id_sel'];
$nombre  = $_REQUEST['nombre'];
$apellidos = $_REQUEST['apellidos'];
$correo = $_REQUEST['correo'];
$password = $_REQUEST['pasw'];
$rol = $_REQUEST['rol'];
$tx = '';
$tx2 =  '';

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
	$tx2 = ", archivo_n = '$file_name', archivo = '$fileName1'";
}


if($password != '')
{
	$password = md5($password);
	$tx = ", pass = '$password'";
}

$sql = "UPDATE administradores SET nombre = '$nombre',
		apellidos = '$apellidos', correo = '$correo',
		rol = $rol $tx $tx2 WHERE id = $id";

$res = mysql_query($sql, $con);

header("Location: Tabla administradores.php");
?>