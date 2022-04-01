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
			FROM administradores
			WHERE status = 1 AND eliminado = 0";
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

		<script>
			function eliminacampo(id, cont)
			{
				var answ = confirm("Esta seguro de borrar este campo?");
				if(answ)
				{	
					$.ajax({
						url : 'elimina_administradores_tabla.php',
  						type : 'post',
  						dataType : 'text',
  						data : 'id='+id,
  						success : function()
  						{
  							$('#fila'+cont).hide();
  							$('#mensaje1').html('Se ha eliminado el administrador');
  							setTimeout("$('#mensaje1').html('')",5000)
		  				} ,error: function()
		  				{
		  					alert('Error al conectar al servidor...');
		  				}
					});

				}
				else
					return false;
			}


		</script>

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
				<td align ="middle" colspan ="1">NOMBRE</td>
				<td align ="middle" colspan ="1">APELLIDOS</td>
				<td align ="middle" colspan ="1">ROL</td>
				<td align ="middle" colspan ="1">DETALLES</td>
				<td align ="middle" colspan ="1">EDITAR</td>
				<td align ="middle" colspan ="1">ELIMINAR</td>
				<td align ="middle" colspan ="1">NOMBRE DE ARCHIVO</td>
				<td align ="middle" colspan ="1">NOMBRE DE ARCHIVO ENCRIPTADO</td>
			</tr>
				<?php
					for($i = 0; $i < $num; $i++)
					{
						$id = mysql_result($res, $i, "id");
						$nombre = mysql_result($res, $i, "nombre");
						$apellidos = mysql_result($res, $i, "apellidos");
						$rol = mysql_result($res, $i, "rol");
						$nom_archivo_enc = mysql_result($res, $i, "archivo");
						$nom_archivo = mysql_result($res, $i, "archivo_n");
						echo "<tr id = \"fila$i\">
								<td>$id</td>
								<td>$nombre</td>
								<td>$apellidos</td>";
								if($rol == 1)
									echo "<td>Gerente</td>";
								else
									echo "<td>Ejeutivo</td>";
								echo "<td><a class = \"links\" href=\"detalles_administradores.php?id=$id\">VER DETALLE</a></td></td>";
								echo "<td><a class = \"links\" href=\"alta_edit.php?id=$id\">EDITAR</a></td>";
								echo "<td><input type =\"button\" id=\"id\" name=\"id\" onClick=\"eliminacampo($id, $i);\"/ id=\"eliminar\" value=\"Eliminar\"></td>
								<td>$nom_archivo</td>
								<td>$nom_archivo_enc</td>
							  </tr>";					
					}
				?>
		</table>
		<a location href="alta_administradores.php"><input type="button" value="Dar de alta" class = "create"></a>
		<div id="mensaje1" class = "notice"></div>
	</body>
</html>