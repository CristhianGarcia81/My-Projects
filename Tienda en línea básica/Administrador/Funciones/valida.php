<?php
session_start();

require "conecta.php";
$con = conecta();
$correo = $_REQUEST['correo'];
$password = $_REQUEST['pass'];
$password = md5($password);

$sql = "SELECT * FROM administradores WHERE correo = '$correo' AND pass = '$password' AND status = 1 AND eliminado = 0";
$res = mysql_query($sql, $con);
$num = mysql_num_rows($res);

if($num)
{
	$idU = mysql_result($res, 0, "id");
	$nombreU = mysql_result($res, 0, "nombre").' '.mysql_result($res, 0, "apellidos");
	$correoU = mysql_result($res, 0, "correo");
	$archivoU = mysql_result($res, 0, "archivo");
	$_SESSION['idU'] = $idU;
	$_SESSION['nombre'] = $nombreU;
	$_SESSION['correo'] = $correoU;
	$_SESSION['archivo'] = $archivoU;
}

echo $num;
?>