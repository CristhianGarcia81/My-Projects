<?php
	session_start();
	if(!$_SESSION['nombre'])
	{
	  header("Location: login.php");
	}
	header('Content-Type: text/html; charset=UTF-8');
	$nombreU = $_SESSION['nombre'];
	require "./Funciones/conecta.php";
	$con =  conecta();
	mysql_query("SET NAMES 'utf8'",$con);
	$id = $_REQUEST['id'];
	$num = 0;
	if($id > 0)
	{
		$sql = "SELECT * FROM productos WHERE id = $id";
		$res = mysql_query($sql,$con);
		$nombre = mysql_result($res, 0, "nombre");
		$codigo = mysql_result($res, 0, "codigo");
		$descripcion = mysql_result($res, 0, "descripcion");
		$costo = mysql_result($res, 0, "costo");
		$stock = mysql_result($res, 0, "stock");
		$archivo = mysql_result($res,0, "archivo");
		$num = mysql_num_rows($res);
	}
?>
<html>
	<head>
		<title>Detalles del producto</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
		<style>
			*
  			{
  				margin: 0;
  				padding: 0;
  				box-sizing: border-box; 
  			}
	  		body
	  		{
	  			background-image: url('Imagenes/Fondo7.jpg');
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
				color: black;
				padding: 10px;
				margin-top: 100px;
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
			<table border="1" class = "table2" width="960">
				<tr>
					<td align="center"><a class = "links" href = "bienvenido.php">INICIO</a></td>
					<td align="center"><a class = "links" href = "Tabla administradores.php">ADMINISTRADORES</a></td>
					<td align="center"><a class = "links" href = "productos.php">PRODUCTOS</a></td>
					<td align="center"><a class = "links" href = "pedidos.php">PEDIDOS</a></td>
					<td align="center"><a class = "links"></a><?php echo "Bienvenido $nombreU"?></td>
					<td align="center"><a class = "links" href = "banners.php">Banners</a></td>
					<td align="center"><a class = "links" href = "cerrar_sesion.php">CERRAR SESION</a></td>
				</tr>
			</table>
			<h4 class = "title">DETALLES DE PRODUCTO</h4>
			<table class="table" width = "1000">
				<tr>
					<td  style = "padding-left: 150px;"><img width="200" src = "Productos/<?php echo $archivo?>"> </td>
					<td>
						<div style = "margin-left: 150px;">
							<?php
								echo "Descripcion: $descripcion";
								echo "<br>";
								echo "Costo: $$costo";
								echo "<br>";
								echo "Stock: $stock";
								echo "<br>";
								echo "Código: $codigo";
							?>
						</div>	
					</td>
				</tr>
			</table>
		</body>
	</html>";
