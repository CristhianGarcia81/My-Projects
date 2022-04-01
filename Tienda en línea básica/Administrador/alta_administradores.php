<?php
session_start();
if(!$_SESSION['nombre'])
{
	header("Location: login.php");
}
$nombreU = $_SESSION['nombre'];
?>

<html>

 <head>
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
 <title>Registro de administradores</title>
 <h4 class = "titulo">ALTA DE ADMINISTRADORES</h4>
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
  	.back
  	{
  		width: 30%;
  		padding: 10px;
  		margin-top: 10px;
  		margin-left: 480px;
  		background: #AAAFFF;
  	}
  	.error
  	{
  		display:inline;
  		color: #FF0000;
  	}
  	.error2
  	{
  		color: #FF0000;
  	}
  </style>

   <script>
  	
  	function recibe()
  	{
  		var nombre = document.forma01.nombre.value;
  		var apellidos = document.forma01.apellidos.value;
  		var correo = document.forma01.correo.value;
  		var rol = document.forma01.rol.value;
  		var password = document.forma01.pasw.value;
		var cont = 0;
		var campos = 0;

		if(rol == 0)
		{
			$('#mensaje2').html('Faltan campos por llenar');
			setTimeout("$('#mensaje2').html('')",5000)
			return false;
		}
		else
		{
			if(rol == 1)
			{
				rol = "Gerente";
				campos++;

			}
			else
			{
				if(rol == 2)
				{
					rol = "Ejecutivo";
					campos++;
				}
			}
		}

		while(cont < forma01.length-1)
		{
  			switch(forma01[cont].type)
  			{
  				case "text":
  				{
  					if(forma01[cont].value == "")
  						break;
  					else
  					{
  						campos++;
  					}
  				}
				break;

  				case "email":
  				{
  					if(forma01[cont].validity.typeMismatch)
  						break;
  					else
  					{
	  					campos++;
  					}
  				}
  				break;

  				case "password":
  				{
  					if(forma01[cont].value == "")
  						break;
  					else
  					{
  						campos++;
  					}
  				}
  				break;
  				case "file":
  				{
  					if(forma01[cont].value == "")
  						break;
  					else
  					{
  						campos++;
  					}
  				}
  			}

  			cont++;
  		}

  		if(campos < 6)
  		{
  			$('#mensaje2').html('Faltan campos por llenar');
  			setTimeout("$('#mensaje2').html('')",5000)
  		}
  		else
  		{
  			document.forma01.action = "salva_administradores.php";
			document.forma01.submit();
  		}

  	}

  	function verificacorreo()
  	{

  		var id = $('#id_sel').val();
  		var correo = $('#correo').val();

  		if(correo != '')
  		{
  			$.ajax({
  				url : 'Funciones/verificaCorreo.php',
  				type : 'post',
  				dataType : 'text',
  				data : 'id='+id+'&correo='+correo,
  				success : function(res)
  				{
  					alert(res);
  					if(res > 0)
  					{
  						$('#mensaje1').html('El correo ' +correo+  ' ya esta registrado');
  						$('#correo').val('');
  						setTimeout("$('#mensaje1').html('')",5000)
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
	<form name="forma01" class = "form1" enctype="multipart/form-data" method="post">
		<label>
			<input id="campo1" type="text" name="nombre"  class = "inputs" placeholder="Escribe tu nombre" required>
		</label>
		<br>
		<label>
			<input id="campo2" type="text" name="apellidos" class = "inputs" placeholder="Escribe tus apellidos" required>
		</label>
		<br>
		<label>
			<input id = "correo" type="email" name="correo" class = "inputs" placeholder="Escribe tu correo" onBlur="verificacorreo();">
		</label>
		<div id="mensaje1" class = "error"></div>
		<br>
		<label for="pasw"></label>
		<input type="password" name="pasw" placeholder="Escribe tu contraseña" class = "inputs">
		<br>
		<label for="rol" ></label>
			<select name="rol" class = "inputs">
				<option value="0" selected>Selecciona Rol</option>
				<option value="1">Gerente</option>
				<option value="2">Ejecutivo</option>			
			</select>
		<h4 align="center" >SELECCIONAR IMAGEN DE PERFIL</h4>	
		<input type="file" id="archivo" name="archivo"><br><br>
		<input onClick="recibe(); return false;" type="submit" value="Registrar" class = "buttons">
		<input type="hidden" id="id_sel" name="id_sel" value="0"/>
		<div id="mensaje2" class = "error2"></div>
	</form>
	<a href="Tabla administradores.php"><input id="campo1" type="button" name="RegresoLista" class = "back" value="Regresar al listado"></a>
 </body>

</html>