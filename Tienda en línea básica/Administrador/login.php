<?php
	session_start();
	if($_SESSION['nombre'])
	{
		header("Location: bienvenido.php");
	}
?>

<html>
	<head>
		<title>Login</title>

		<script src="Js/Jquery-3.3.1.min.js"></script>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
		  		margin-top: 50px;
		  		color: #0066CC;
				font-size: 60px;
				text-align: center;
				font-style: italic;
		  	}
		  	.form1
		  	{
		  		width: 400px;
		  		background: #24303C;
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

		   	.error
		  	{
		  		display:inline;
		  		color: #FF0000;
		  	}
		</style>
		<script>
			function recibe()
			{	
		  		var correo = document.form01.correo.value;
		  		var password = document.form01.password.value;
				var cont = 0;
				var campos = 0;

				while(cont < form01.length-1)
				{
		  			switch(form01[cont].type)
		  			{
		  				case "email":
		  				{
		  					if(form01[cont].value == '')
		  						break;
		  					else
		  					{
			  					campos++;
		  					}
		  				}
		  				break;

		  				case "password":
		  				{
		  					if(form01[cont].value == "")
		  						break;
		  					else
		  					{
		  						campos++;
		  					}
		  				}
		  				break;
		  			}

		  			cont++;
		  		}
		  		
		  		if(campos < 2)
		  		{
		  			$('#mensaje1').html('Faltan campos por llenar');
		  			setTimeout("$('#mensaje1').html('')",5000)
		  		}
		  		else
		  		{
		  			var correo = $('#correo').val();
					var pass = $('#password').val();

		  			$.ajax({
			  			url : 'Funciones/valida.php',
			  			type : 'post',
			  			data : 'correo='+correo+'&pass='+pass,
		 				success : function(res)
		 				{
	  						if(res > 0)	
	 	  					{
	 	  						window.location.href ='bienvenido.php';
		   					}
		   					else
		   					{
		   						$('#mensaje2').html('Datos incorrectos');
		  						$('#correo').val('');
		  						$('#password').val('');
		  						setTimeout("$('#mensaje2').html('')",5000)
		   					}

			  				} ,error: function()
			  				{
			  					alert('Error al conectar al servidor...');
			  				}
  					});
		  		}

			}

		</script>

	</head>

	<body>
		<h4 class ="titulo"> LOGIN </h4>
		<form name = "form01" id= "form01" class ="form1" method = "post">
			<input type="email" name="correo" id = "correo" placeholder="Escribe tu correo" class="inputs">
			<input type="password" name="password" id="password" placeholder="Escribe tu contraseña" class="inputs">
			<input onClick="recibe(); return false;" type="submit" value="Iniciar sesión" class = "buttons" class="buttons">
			<div id="mensaje1" class = "error"></div>
			<div id="mensaje2" class = "error"></div>
		</form>
		
	</body>
</html>