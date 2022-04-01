<?php
require "./Funciones/conecta.php";
$con =  conecta();

$id = $_REQUEST['id'];

if($id > 0)
{
	//$sql = "DELETE FROM administradores WHERE id = $id";
	$sql = "UPDATE administradores
			SET eliminado = 1 WHERE id = $id";
	$res = mysql_query($sql,$con);
}

header("Location: lista_administradores.php");

?>