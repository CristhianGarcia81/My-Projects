<?php
	require "./Funciones/conecta.php";
	$con = conecta();
	$sqlid = "SELECT * FROM pedidos WHERE status = 0";
	$resid = mysql_query($sqlid, $con);
	$numid = mysql_num_rows($resid);
	if($numid == 0)
	{
		echo "<h4></h4>";
	}
	else
	{
		$idPedido = mysql_result($resid, $numid-1, "id");
		$sql = "SELECT * FROM pedidos_productos WHERE id_pedido = $idPedido";
		$res = mysql_query($sql, $con);
		$num = mysql_num_rows($res);
	}
	
?>

<html>
	<head>
		<title>Carrito</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  		<script src="Js/Jquery-3.3.1.min.js"></script>
		
		<script>
			
			function recibe()
			{
				document.forma01.action = "carrito_comfirm.php";
  				document.forma01.submit();
			}

			function eliminarp(id, cont)
			{
				var answ = confirm("Esta seguro de borrar este producto del carrito?");
				if(answ)
				{
					$.ajax({
						url : 'carrito_eliminar.php',
  						type : 'post',
  						dataType : 'text',
  						data : 'id='+id,
  						success : function()
  						{
  							$('#fila'+cont).hide();
  							$('#mensaje1').html('Se ha eliminado el producto');
  							setTimeout("$('#mensaje1').html('')",5000)
  							window.location.reload(); 
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
  				color: white;
  				background: #8A9597;
  				font-family: 'arial';
  			}
  			.table2
  			{
  				margin: auto;
  				color: black;
  				font-family: 'arial';
  			}
  			.form1
	        {
	          width: 400px;
	          padding: 30px;
	          margin: auto;
	          margin-top: 50px;
	          border-radius: 4px;
	          font-family: 'arial';
	          color: white;
	        }
	        .inputs
	        {
	          width: 100%;
	          background: #24303C;
	          padding: 10px;
	          border-radius: 4px;
	          margin-bottom: 16px;
	          border: 1px solid #1F53C5;
	          font-family: 'arial';
	          font-size: 18px;
	          color: white;
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
  			.footer
  			{
  				margin: auto;
				color: #0066cc;
				font-size: 20px;
				text-align: center;
				font-style: italic;
  			}
		</style>

		<table border="1" width="960" class = "table2">
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
		<form name="forma01" enctype="multipart/form-data" method="post">
			<br>
			<table border = "1" width = "960" colspan = "5" class = "table">
				<tr>
					<td>PRODUCTO</td>
					<td>CANTIDAD</td>
					<td>COSTO UNITARIO</td>
					<td>SUBTOTAL</td>
					<td>ELIMINAR</td>
				</tr>
				<?php
					if($num == 0)
					{
						echo "<h4 class = \"titulo\">Aun no hay productos en tu carrito</h4>";
					}
					else
					{
						echo "<h4 class = \"titulo\">Carrito</h4>";
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
									<td align = \"center\">$nombre</td>
									<td align = \"center\">$cantidad</td>
									<td align = \"center\">$$costo</td>
									<td align = \"center\">$$unitario</td>
									<td align = \"center\"><input type =\"button\" name =\"eliminar\" id = \"eliminar\" onclick = \"eliminarp($idProducto,$i);\" value =\"ELIMINAR\"></td>
								</tr>";
						}
						echo 
							"<tr>
								<td align = \"center\">-</td>
								<td align = \"center\">-</td>
								<td align = \"center\">-</td>
								<td align = \"center\">TOTAL: $$total</td>
								<td align = \"center\">-</td>
							</tr>";
					}
				?>
			</table>
			<?php
				if($num != 0)
				{
				echo "<input type=\"submit\" name =\"continuar\" id = \"continuar\" value = \"Continuar\" onclick = \"recibe();\" class = \"create\"/>";
				}
				
			?>
		</form>
		<h4 class = "footer">ATOM-MARKET TODOS LOS DERECHOS RESERVADOS | TERMINOS Y CONDICIONES | POLITICA DE PRIVACIDAD | Facebook/Atom-market</h4>
	</body>
</html>