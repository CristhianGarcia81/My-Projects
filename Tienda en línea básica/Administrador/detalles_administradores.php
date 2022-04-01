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
	$sql = "SELECT * FROM administradores WHERE id = $id";
	$res = mysql_query($sql,$con);
	$nombre = mysql_result($res, 0, "nombre");
	$apellidos = mysql_result($res, 0, "apellidos");
	$rol = mysql_result($res, 0, "rol");
	$status = mysql_result($res, 0, "status");
	$archivo = mysql_result($res,0, "archivo");
	$num = mysql_num_rows($res);
}

echo "<html>
		<head>
			<title>Detalles de administrador</title>
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
			<h4 class = \"title\">DETALLES DE ADMINISTRADOR</h4>
			<a href=\"Tabla administradores.php\"><input id=\"campo1\" type=\"button\" name=\"RegresoLista\" class = \"back\" value=\"Regresar al listado\"></a>
			<table border = \"1\" colspan = \"1\" width = \"400\" class = \"table\">
				<tr> 
					<td class = \"rows\">Nombre completo:</td>
				</tr>
				<tr> 
					<td class = \"columns\">$nombre  $apellidos</td>
				</tr>
				<tr>
					<td class = \"rows\"> Rol: </td>
				</tr>";
				if($rol == 1)
					echo "<tr><td class = \"columns\"> Gerente </td></tr> ";
				else
					echo "<tr><td class = \"columns\"> Ejecutivo </td></tr> ";				

			echo "<tr> 
					<td class = \"rows\">Status</td>
				</tr>";
				if($status ==  1)
					echo "<tr> <td class = \"columns\"> Activo </td> </tr>";
				else
					echo"<tr> <td class = \"columns\"> Inactivo </td> </tr>";
				
				echo "<tr><td class = \"rows\">Imagen de perfil:</td></tr>
					<tr>
						<td><img width=\"374\" src = \"archivos/$archivo\"/></td>
					</tr>
			</table>
		</body>
	</html>";
?>





