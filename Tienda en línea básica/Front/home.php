<?php
	header('Content-Type: text/html; charset=UTF-8'); 
	require "./Funciones/conecta.php";
	$con = conecta();
	mysql_query("SET NAMES 'utf8'",$con);

	$sql = "SELECT * FROM banners";
	$res = mysql_query($sql, $con);
	$num = mysql_num_rows($res);

	$ids = rand(1, $num);
	$sqlban = "SELECT * FROM banners WHERE id = $ids";
	$resban = mysql_query($sqlban, $con);
	$nombre = mysql_result($resban, 0, "nombre");
    $status = mysql_result($resban, 0, "status");
    $archivo = mysql_result($resban,0, "archivo");
    $numban = mysql_num_rows($resban);
    $cont = 0;
    $band = 0;
?>

<html>
	<head>
		<title>ATOM-MARKET HOME</title>
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
		<h4 align = "center" ><img src = "Banners/<?php echo $archivo;?>"/></h4>
		<br><br><br>
		<table class = "table" width = "1000">
			<tr>
				
				<?php
					for($i = 0; $i < 3; $i++)
					{
						$sqlp = "SELECT * FROM productos";
						$resp = mysql_query($sqlp, $con);
						$nump = mysql_num_rows($resp);
					    $idp = rand(3, $nump);
					   /* $idaux = array();
					    array_push($idaux, $idp);
					    $cont++;
					    
					    if($band == 1)
					    {
					    	for($j = 0; $j < $cont; $j++)
						    {
						    	if($idp == $idaux[$j])
						    	{
						    		$idp = rand(3, $nump);
						    	}
						    }
					    }
						    
						$band = 1;*/
					    $sqlpro = "SELECT * FROM productos WHERE id = $idp";
					    $respro = mysql_query($sqlpro, $con);
					    $nombrepro = mysql_result($respro, 0, "nombre");
					    $codigopro = mysql_result($respro, 0, "codigo");
					    $descripcionpro = mysql_result($respro, 0 , "descripcion");
					    $costopro = mysql_result($respro, 0, "costo");
					    $stockpro = mysql_result($respro, 0 , "stock");
					    $archivopro = mysql_result($respro, 0, "archivo");
					    $archivopro_n = mysql_result($respro, 0, "archivo_n"); 
					    $statuspro = mysql_result($respro, 0, "status");

						echo "<td><h4 align = \"center\"><img src = \"Productos/$archivopro\" width = \"150\"/><h4><br>
							<h4 align = \"center\">$nombrepro</h4><br>
							<h4 align = \"center\">$$costopro</h4>
							<br>
							<h4 align = \"center\"><a href =\"productos_detalles.php?id=$idp\">Detalles</a></h4>
							</td>";
					}
				?>
			</tr>
		</table>
		<h4 class = "footer">ATOM-MARKET TODOS LOS DERECHOS RESERVADOS | TERMINOS Y CONDICIONES | POLITICA DE PRIVACIDAD | Facebook/Atom-market</h4>
	</body>
</html>