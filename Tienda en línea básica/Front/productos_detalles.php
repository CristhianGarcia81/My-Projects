<?php
	header('Content-Type: text/html; charset=UTF-8');
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
		<script src="Js/Jquery-3.3.1.min.js"></script>
		<script>
			function recibe()
			{
				var idProducto = document.forma01.idProducto.value;
				var cantidad = document.forma01.cantidad.value;
				document.forma01.action = "carrito.php";
  				document.forma01.submit();
			}
		</script>
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
		 	.create
  			{ 
  				background: #AAAFFF;
  				padding: 5px;
  			}
  			.footer
  			{
  				margin: auto;
				color: #0066cc;
				font-size: 20px;
				text-align: center;
				font-style: italic;
  			}
			</style>
			<table border="1" width="960" class = "table">
		      	<tr>
			      	<td align="center"><img src = "Imagenes/Atom_Market.png" width="50" height="50"/></td>
			        <td align="center"><a class = "links" href = "home.php">Home</a></td>
			        <td align="center"><a class = "links" href = "productos_cliente.php">Productos</a></td>
			        <td align="center"><a class = "links" href = "contacto.php">Contacto</a></td>
			        <td align="center"><a class = "links" href = "Carrito_form.php">Carrito</a></td>
		      	</tr>
    		</table>
		</head>

		<body>
			<h4 class = "title">DETALLES DE PRODUCTO</h4>
			<form name="forma01" class = "form1" enctype="multipart/form-data" method="post">
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
									echo "<br>";
								?>
								<br>
								<h4 class = "text">Seleccione cantidad<h4><br>
								<input type = "number" name = "cantidad" id = "cantidad" value = "1"/>
								<br>
								<input class = "create" type = "submit" value = "Añadir al carrito" onclick="recibe();" />
								<input type="hidden" id="idProducto" name="idProducto" value="<?php echo $id?>"/>
							</div>	
						</td>
					</tr>
				</table>
			</form>
			<h4 class = "footer">ATOM-MARKET TODOS LOS DERECHOS RESERVADOS | TERMINOS Y CONDICIONES | POLITICA DE PRIVACIDAD | Facebook/Atom-market</h4>
		</body>
	</html>
