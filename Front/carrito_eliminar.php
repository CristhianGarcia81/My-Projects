<?php
require "./Funciones/conecta.php";
$con =  conecta();

$id = $_REQUEST['id'];
$num = 0;
if($id > 0)
{
	$sql = "DELETE FROM pedidos_productos WHERE id_producto = $id";
	$res = mysql_query($sql,$con);
	$num = mysql_num_rows($res);
}
echo $num;

?>