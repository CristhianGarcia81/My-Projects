<html>
	<head>
		<title></title>
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
          margin-top: 50px;
          color: #0066CC;
          font-size: 60px;
          text-align: center;
          font-style: italic;
        }
        .table
  		{
  			margin: auto;
  			color: black;
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
        .form1
        {
          width: 400px;
          background: #8A9597;
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
        .buttons
        {
          width:100%;
          padding: 16px;
          margin: auto;
          background: #AAAFFF;
        }
        .back
        {
          width: 30%;
          padding: 10px;
          margin-top: 10px;
          margin-left: 480px;
          background: #AAAFFF;
        }
        .msj
        {
          display:inline;
          color: #FF0000;
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

  		<script>
  			function recibe()
  			{
  				document.forma01.action = "enviar_correo.php";
  				document.forma01.submit();
			    $('#mensaje1').html('Mensaje Enviado');
      			setTimeout("$('#mensaje1').html('')",5000)
			    
  			}
  		</script>

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
		<h4 class = "titulo">CONTÁCTANOS</h4>
		<form name="forma01" class = "form1" enctype="multipart/form-data" method="post">
		<label>
			<input id="nombre" type="text" name="nombre"  class = "inputs" placeholder="Escribe tu nombre" required>
		</label>
		<br>
		<label>
			<input id="apellidos" type="text" name="apellidos" class = "inputs" placeholder="Escribe tus apellidos" required>
		</label>
		<br>
		<label>
			<input id = "correo" type="email" name="correo" class = "inputs" placeholder="Escribe tu correo">
		</label>
		<br>
		<textarea id = "mensaje" name="mensaje" placeholder="Mensaje" cols="30" rows="5" class = "inputs" required></textarea>
		<br>
		<input onClick="recibe(); return false;" type="submit" value="Enviar" class = "buttons"><br>
		<div id = "mensaje1" name = "mensaje1" class = "msj"></div>
	</form>
	<h4 class = "footer">ATOM-MARKET TODOS LOS DERECHOS RESERVADOS | TERMINOS Y CONDICIONES | POLITICA DE PRIVACIDAD | Facebook/Atom-market</h4>
	</body>
</html>