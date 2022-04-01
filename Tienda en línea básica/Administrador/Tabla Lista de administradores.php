<?php
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
			.titulo
			{
				color: #0066cc;
				font-size: 60px;
				text-align: center;
				font-style: italic;
			}
		
		</style>

	</head>

	<body>

		<text class = "titulo">LISTA DE ADMINISTRADORES</text><br>
		<table border="1" width="960">
			<tr>
				<td align ="middle" colspan ="5">Lista de administradores</td><br>
				<a location href="alta_administradores.php"><input type="button" value="CREAR CAMPO"></a>
			</tr>
				<?php
					for($i = 0; $i < $num; $i++)
					{
						$id = mysql_result($res, $i, "id");
						$nombre = mysql_result($res, $i, "nombre");
						$apellidos = mysql_result($res, $i, "apellidos");
						$rol = mysql_result($res, $i, "rol");
						echo "<tr>
								<td>$id</td>
								<td>$nombre</td>
								<td>$apellidos</td>";
								if($rol == 1)
									echo "<td>Gerente</td>";
								else
									echo "<td>Ejeutivo</td>";
								echo "<td><a href=\"elimina_administradores_tabla.php?id=$id\">Click para eliminar</a></td>
							  </tr>";
					}
				?>
		</table>
	</body>
</html>