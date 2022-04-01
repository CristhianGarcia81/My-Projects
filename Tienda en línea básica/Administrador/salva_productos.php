<?php
header('Content-Type: text/html; charset=UTF-8'); 
require "./Funciones/conecta.php";
$con = conecta();
mysql_query("SET NAMES 'utf8'",$con);


$nombre = $_REQUEST['nombre'];
$codigo = $_REQUEST['codigo'];
$descripcion = $_REQUEST['descripcion'];
$costo = $_REQUEST['costo'];
$stock = $_REQUEST['stock'];

$file_name = $_FILES['archivo']['name'];
$file_tmp = $_FILES['archivo']['tmp_name'];
$cadena = explode(".", $file_name);
$ext = end($cadena);
$dir = "Productos/";
$file_enc = md5_file($file_tmp);


if($file_name != '')
{
	$fileName1 = "$file_enc.$ext";
	copy($file_tmp, $dir.$fileName1);
}

$sql = "INSERT INTO productos VALUES
		(0,'$nombre', '$codigo', '$descripcion', '$costo', '$stock',
		'$file_name', '$fileName1', 1, 0)";
$res = mysql_query($sql, $con);

header("Location: productos.php");


?>