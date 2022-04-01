<?php
	session_start();
	if(!$_SESSION['nombre'])
	{
		header("Location: login.php");
	}
	$nombreU = $_SESSION['nombre'];
	header('Content-Type: text/html; charset=UTF-8'); 
	require "./Funciones/conecta.php";
	$con = conecta();
	mysql_query("SET NAMES 'utf8'",$con);
	$sql = "SELECT *
			FROM productos
			WHERE status = 1 AND eliminado = 0";
	$res = mysql_query($sql, $con);
	$num = mysql_num_rows($res);
?>

<html>
	<head>
		<title>PRODUCTOS</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  		<script src="Js/Jquery-3.3.1.min.js"></script>
		
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
			.titulo
			{
				margin: auto;
				color: #0066cc;
				font-size: 60px;
				text-align: center;
				font-style: italic;
			}
			.notice
  			{
  				display:inline;
  				color: #FF0000;
  			}
  			.table
  			{
  				margin: auto;
  				color: black;
  				font-family: 'arial';
  			}
  			.links
  			{
  				text-decoration: underline;
  				color: black;
  			}
  			.create
  			{
  				margin-left: 550px;
  				margin-top: 50px; 
  				background: #AAAFFF;
  				width: 20%;
  				padding: 5px;
  			}
		</style>


		<script>
			function alta()
			{
				window.location.href = 'productos_alta.php';
			}	
		</script>
	</head>

	<body>
		<table border="1" align = "center" class = "table" width="960">
			<tr>
				<td align="center"><a class = "links" href = "bienvenido.php">INICIO</a></td>
				<td align="center"><a class = "links" href = "Tabla administradores.php">ADMINISTRADORES</a></td>
				<td align="center"><a class = "links" href = "productos.php">PRODUCTOS</a></td>
				<td align="center"><a class = "links" href = "pedidos.php">PEDIDOS</a></td>
				<td align="center"><a class = "links"></a>Bienvenido <?php echo $nombreU;?></td>
				<td align="center"><a class = "links" href = "banners_listado.php">Banners</a></td>
				<td align="center"><a class = "links" href = "cerrar_sesion.php">CERRAR SESION</a></td>
			</tr>
		</table>

		<h4><input Onclick = "alta();" type="button" value = "Dar de alta" class = "create"></h4>
		
		<table width = "1000" class = "table">
			<?php
				$i = 0;
				$cont = 0;
				$band = 0;
				for(; $i < $num; $i++)
				{
					$id = mysql_result($res, $i, "id");
					$nombre = mysql_result($res, $i, "nombre");
					$codigo = mysql_result($res, $i, "codigo");
					$descripcion = mysql_result($res, $i, "descripcion");
					$costo = mysql_result($res, $i, "costo");
					$stock = mysql_result($res, $i, "stock");
					$nom_archivo_enc = mysql_result($res, $i, "archivo");
					$nom_archivo = mysql_result($res, $i, "archivo_n");
					if($band == 0)
					{
						echo "<tr width =\"50\" height=\"100\">
								<td width =\"150\">
									<h4 align = \"center\"><img width=\"150\" src = \"Productos/$nom_archivo_enc\"/></h4><br>
								<h4 align = \"center\">$nombre</h4><br>
								<h4 align = \"center\">Stock: $stock</h4><br>
								<h4 align = \"center\"> $$costo</h4><br>
								<h4 align = \"center\"><a href =\"productos_detalles.php?id=$id\">Detalles</a>&nbsp;&nbsp;<a href =\"productos_edit.php?id=$id\">Editar</a><br>
								<h4 align = \"center\"><a href =\"productos_eliminar.php?id=$id\">Eliminar</a></td>";
						$band = 1;
						$cont++;
					}
					else
					{
						if($cont == 3)
						{
							echo 
							"</tr>
								<tr width =\"50\" height=\"100\">
									<td width =\"150\" height=\"100\">
									<h4 align = \"center\"><img width=\"150\" src = \"Productos/$nom_archivo_enc\"/></h4><br>
									<h4 align = \"center\">$nombre</h4><br>
									<h4 align = \"center\">Stock: $stock</h4><br>
									<h4 align = \"center\"> $$costo</h4><br>
									<h4 align = \"center\"><a href =\"productos_detalles.php?id=$id\">Detalles</a>&nbsp;&nbsp;<a href =\"productos_edit.php?id=$id\">Editar</a><br>
									<h4 align = \"center\"><a href =\"productos_eliminar.php?id=$id\">Eliminar</a></td>";
							$cont = 1;
						}
						else
						{
							echo "<td width =\"150\" height=\"100\">
									<h4 align = \"center\"><img width=\"150\" src = \"Productos/$nom_archivo_enc\"/></h4><br>
									<h4 align = \"center\">$nombre</h4><br>
									<h4 align = \"center\">Stock: $stock</h4><br>
									<h4 align = \"center\"> $$costo</h4><br>
									<h4 align = \"center\"><a href =\"productos_detalles.php?id=$id\">Detalles</a>&nbsp;&nbsp;<a href =\"productos_edit.php?id=$id\">Editar</a><br>
									<h4 align = \"center\"><a href =\"productos_eliminar.php?id=$id\">Eliminar</a></td>";
							$cont++;
						}
					}	
				}
			?>
		</table>
	</body>
</html>