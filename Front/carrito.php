<?php
	session_start();

	require "./Funciones/conecta.php";
	$con = conecta();
	
	$idProducto = $_REQUEST['idProducto'];
	$cantidad = $_REQUEST['cantidad'];
	$fecha = date('Ymd');
	if($_SESSION['usuario'])
	{
		$usuario = $_SESSION['usuario'];
	}
	else
	{
		$_SESSION['usuario'] = time()+rand();
	}

	//verifica si hay pedido

	$sql = "SELECT * FROM pedidos WHERE status = 0 AND usuario = $usuario";
	$res = mysql_query($sql, $con);
	$num = mysql_num_rows($res);
	//echo $num;
	if($num == 1)
	{
		$idPedido = mysql_result($res, 0, "id");
	}
	else
	{
		$sql = "INSERT INTO pedidos VALUES (0, $fecha, $usuario, 0)";
		$res = mysql_query($sql, $con);
		$idPedido = mysql_insert_id($con);
	}
	//saca costo
	$sql = "SELECT * FROM productos WHERE id = $idProducto";
	$res = mysql_query($sql, $con);
	$costo = mysql_result($res, 0, "costo");


	//verifica si existe el producto

	$sql = "SELECT * FROM pedidos_productos WHERE id_producto =$idProducto AND id_pedido = $idPedido";
	$res = mysql_query($sql, $con);
	$num = mysql_num_rows($res);
	if($num == 1)
	{
		///actualizar
		$idPP = mysql_result($res, 0, "id");
		$sql = "UPDATE pedidos_productos SET cantidad = cantidad + $cantidad WHERE id = $idPP";
		$res = mysql_query($sql, $con);
	}
	else
	{
		//insertar producto
		$sql = "INSERT INTO pedidos_productos VALUES (0, $idPedido, $idProducto, $cantidad, $costo)";
		$res = mysql_query($sql, $con);
	}

	header("Location: Carrito_form.php");
?>