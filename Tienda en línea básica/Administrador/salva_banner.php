<?php
	header('Content-Type: text/html; charset=UTF-8'); 
	require "./Funciones/conecta.php";
	$con = conecta();
	mysql_query("SET NAMES 'utf8'",$con);

	$nombre = $_REQUEST['nombre'];
	$file_name = $_FILES['archivo']['name'];
	$file_tmp = $_FILES['archivo']['tmp_name'];
	$cadena = explode(".", $file_name);
	$ext = end($cadena);
	$dir = "Banners/";
	$file_enc = md5_file($file_tmp);


	if($file_name != '')
	{
		$fileName1 = "$file_enc.$ext";
		copy($file_tmp, $dir.$fileName1);
	}

	$sql = "INSERT INTO banners VALUES
			(0,'$nombre', '$fileName1', 1, 0)";
	$res = mysql_query($sql, $con);
	header("Location: banners_listado.php");
?>