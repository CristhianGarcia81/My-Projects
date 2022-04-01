<?php
session_start();
if(!$_SESSION['nombre'])
{
	header("Location: login.php");
}
$nombreU = $_SESSION['nombre'];
$archivoU = $_SESSION['archivo'];
?>

<html>
	<head>
		<title>Sistema de administracion</title>
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
		  		color: #0066CC;
				font-size: 20px;
				text-align: center;
				font-style: italic;
			}

			.table
			{
				margin: auto;
  				color: white;
  				font-family: 'arial';
  				background: #8899AA;
  				text-decoration: underline;
			}

		</style>
		<script>

			function cerrar()
			{
				window.location.href ='cerrar_sesion.php';
			}

		</script>
	</head>
	<body style="font-family: helvetica">
		<div style="text-align: center" class = "title"></div>
		<br>
		<table border="1" class = "table" width="960">
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

		<h4 class = "title">BIENVENIDO AL SISTEMA DE ADMINISTRADORES</h4>
		<h4 align="center"><img align = "middle" width="374" src = "archivos/<?php echo $archivoU; ?>"/></h4>
	</body>
</html>