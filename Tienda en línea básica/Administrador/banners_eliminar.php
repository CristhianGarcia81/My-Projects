<?php
require "./Funciones/conecta.php";
$con =  conecta();

$id = $_REQUEST['id'];
$num = 0;
if($id > 0)
{
	$sql = "UPDATE banners
			SET eliminado = 1 WHERE id = $id";
	$res = mysql_query($sql,$con);
	$num = mysql_num_rows($res);
}
echo $num;

?>