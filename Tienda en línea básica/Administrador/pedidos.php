<?php
	session_start();
	if(!$_SESSION['nombre'])
	{
		header("Location: login.php");
	}
	$nombreU = $_SESSION['nombre'];
	require "./Funciones/conecta.php";
	$con = conecta();

	$sql = "SELECT *
			FROM pedidos
			WHERE status = 1";
	$res = mysql_query($sql, $con);
	$num = mysql_num_rows($res);
?>

<html>
	<head>
		<title>Lista de administradores</title>
		
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
  				background-image: url('Imagenes/Fondo2.jpg');
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
  				color: white;
  				font-family: 'arial';
  				background: #24303C;
  			}
  			.table2
  			{
  				margin: auto;
  				color: white;
  				font-family: 'arial';
  				background: #8899AA;
  				text-decoration: underline;
  			}
  			.links
  			{
  				text-decoration: underline;
  				color: white;
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

	</head>

	<body>
		<table border="1" class = "table2" width="960">
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
		<h4 class = "titulo">LISTA DE ADMINISTRADORES</h4>
		<table border="1" width="960" class = "table">
			<tr>
				<td align ="middle" colspan ="9">Lista de administradores</td><br>
			</tr>
			<tr>
				<td align ="middle" colspan ="1">ID</td>
				<td align ="middle" colspan ="1">FECHA</td>
				<td align ="middle" colspan ="1">USUARIO</td>
				<td align ="middle" colspan ="1">DETALLES</td>
			</tr>
				<?php
					for($i = 0; $i < $num; $i++)
					{
						$id = mysql_result($res, $i, "id");
						$fecha = mysql_result($res, $i, "fecha");
						$usuario = mysql_result($res, $i, "usuario");
						echo "<tr id = \"fila$i\">
								<td>$id</td>
								<td>$fecha</td>
								<td>$usuario</td>";
								echo "<td><a class = \"links\" href=\"pedidos_detalles.php?id=$id\">VER DETALLE</a></td></td>
							  </tr>";					
					}
				?>
		</table>
	</body>
</html>