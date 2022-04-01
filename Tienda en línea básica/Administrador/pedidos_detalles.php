<?php
	session_start();
	if(!$_SESSION['nombre'])
	{
	  header("Location: login.php");
	}
	$nombreU = $_SESSION['nombre'];
	require "./Funciones/conecta.php";
	$con =  conecta();
	$id = $_REQUEST['id'];
	$num = 0;
	if($id > 0)
	{
		$sql = "SELECT * FROM pedidos_productos WHERE id_pedido = $id";
		$res = mysql_query($sql,$con);
		$cantidad = mysql_result($res, 0, "cantidad");
		$costo = mysql_result($res,0, "precio");
		$num = mysql_num_rows($res);
	}

echo "<html>
		<head>
			<title>Detalles de banner</title>
			<style>
				*
  				{
  					margin: 0;
  					padding: 0;
  					box-sizing: border-box; 
  				}
	  			body
	  			{
	  				background-image: url('Imagenes/Fondo2.jpg');
	  			}
	  			.title
	  			{
	  				margin-top: 50px;
	  				font-style: italic;
	  				text-align: center;
	  				color: #0066CC;
	  				font-size: 60px;
	  			}
				.table
				{
					margin: auto;
					color: white;
					padding: 10px;
					margin-top: 100px;
					background: #24303C;
					font-family: 'arial';
				}
				.table2
  				{
  					margin: auto;
  					color: white;
  					font-family: 'arial';
  					background: #8899AA;
  					text-decoration: underline;
  				}
				.rows
				{
					text-align: center;
					color: #AAAFFF;
				}
				.columns
				{
					text-align: center;
					color: white;
					text-decoration: underline;
				}
				.back
			  	{
			  		width: 30%;
			  		padding: 10px;
			  		margin-left: 480px;
			  		background: #AAAFFF;
			  	}
			</style>
		</head>

		<body>
		<table border=\"1\" class = \"table2\" width=\"960\">
			<tr>
				<td align=\"center\"><a class = \"links\" href = \"bienvenido.php\">INICIO</a></td>
				<td align=\"center\"><a class = \"links\" href = \"Tabla administradores.php\">ADMINISTRADORES</a></td>
				<td align=\"center\"><a class = \"links\" href = \"productos.php\">PRODUCTOS</a></td>
				<td align=\"center\"><a class = \"links\" href = \"pedidos.php\">PEDIDOS</a></td>
				<td align=\"center\"><a class = \"links\"></a>Bienvenido $nombreU</td>
				<td align=\"center\"><a class = \"links\" href = \"banners_listado.php\">Banners</a></td>
				<td align=\"center\"><a class = \"links\" href = \"cerrar_sesion.php\">CERRAR SESION</a></td>
			</tr>
		</table>
			<h4 class = \"title\">DETALLES DEL PEDIDO</h4>
			<a href=\"pedidos.php\"><input id=\"campo1\" type=\"button\" name=\"RegresoLista\" class = \"back\" value=\"Regresar al listado\"></a>
			<table border = \"1\" colspan = \"1\" width = \"400\" class = \"table\">
				<tr> 
					<td class = \"rows\">ID PRODUCTO</td>
					<td class = \"columns\">NOMBRE</td>
					<td class = \"rows\">CANTIDAD</td>
					<td class = \"rows\">COSTO UNITARIO</td>
					<td class = \"rows\">SUBTOTAL</td>
				</tr>";

					for($i = 0; $i < $num; $i++)
					{			
						$cantidad = mysql_result($res, $i, "cantidad");
						$costo = mysql_result($res, $i, "precio");
						$unitario = ($cantidad * $costo);
						$total = $total + $unitario;
						$idProducto = mysql_result($res, $i, "id_producto");
						$sqlp = "SELECT nombre FROM productos WHERE id = $idProducto";
						$resp = mysql_query($sqlp, $con);
						$nombre = mysql_result($resp, 0, "nombre");
						echo 
							"<tr id = \"fila$i\">
							<td align = \"center\">$idProducto</td>
							<td align = \"center\">$nombre</td>
							<td align = \"center\">$cantidad</td>
							<td align = \"center\">$$costo</td>
							<td align = \"center\">$$unitario</td>
							</tr>";
					}
						echo 
							"<tr>
								<td align = \"center\">-</td>
								<td align = \"center\">-</td>
								<td align = \"center\">-</td>
								<td align = \"center\">-</td>
								<td align = \"center\">TOTAL: $$total</td>
							
							</tr>
				</tr>
			</table>
		</body>
	</html>";
?>