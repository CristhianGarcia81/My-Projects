<?php
require "./Funciones/conecta.php";
$con = conecta();

$id = $_REQUEST['id_sel'];
$nombre  = $_REQUEST['nombre'];
$codigo = $_REQUEST['codigo'];
$descripcion = $_REQUEST['descripcion'];
$costo = $_REQUEST['costo'];
$stock = $_REQUEST['stock'];
$tx2 =  '';

$file_name = $_FILES['archivo']['name'];
$file_tmp = $_FILES['archivo']['tmp_name'];
$cadena = explode(".", $file_name);
$ext = end($cadena);
$dir = "Productos/";


if($file_name != '')
{
	$file_enc = md5_file($file_tmp);
	$fileName1 = "$file_enc.$ext";
	copy($file_tmp, $dir.$fileName1);
	$tx2 = ", archivo_n = '$file_name', archivo = '$fileName1'";
}


$sql = "UPDATE productos SET nombre = '$nombre',
		codigo = '$codigo', descripcion = '$descripcion',
		costo = $costo, stock = $stock $tx2 WHERE id = $id";

$res = mysql_query($sql, $con);

header("Location: productos.php");
?>