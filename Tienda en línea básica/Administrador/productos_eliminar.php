<?php
require "./Funciones/conecta.php";
$con =  conecta();

$id = $_REQUEST['id'];

if($id > 0)
{
	$sql = "UPDATE productos
			SET eliminado = 1 WHERE id = $id";
	$res = mysql_query($sql,$con);
}

header("Location: productos.php");

?>