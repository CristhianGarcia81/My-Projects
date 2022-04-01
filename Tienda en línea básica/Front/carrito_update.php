<?php

	require "./Funciones/conecta.php";
	$con = conecta();

	$idPedido = $_REQUEST['pedido'];
	$idProductoup = $_REQUEST['id'];	
	$cantaux = $_REQUEST['cant'];
	//UPDATE pedidos_productos SET cantidad = 8 WHERE id_pedido = 3 AND id_producto = 5
 	$sqlcant = "UPDATE pedidos_productos SET cantidad = $cantaux WHERE id_pedido = $idPedido AND id_producto = $idProductoup";
	$rescant = mysql_query($sqlcant, $con);
	//header("Location: Carrito_form.php");
?>