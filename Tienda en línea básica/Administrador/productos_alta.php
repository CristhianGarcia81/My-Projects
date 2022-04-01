<?php
	session_start();
	if(!$_SESSION['nombre'])
	{
		header("Location: login.php");
	}
	$nombreU = $_SESSION['nombre'];
	header('Content-Type: text/html; charset=UTF-8');
	require "./Funciones/conecta.php";
	$con =  conecta();
	mysql_query("SET NAMES 'utf8'",$con);
?>


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
		    .error1
		    {
		      color: #FF0000;
		    }
		 </style>

		<script>
			function recibe()
			{
				var nombre = document.forma01.nombre.value;
			    var codigo = document.forma01.codigo.value;
		        var descripcion = document.forma01.descripcion.value;
		        var costo = document.forma01.costo.value;
	            var stock = document.forma01.stock.value;
	            var archivo = document.forma01.archivo.value;
		        var cont = 0;
    	        var campos = 0;

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

			          case "number":
			          {
			            if(forma01[cont].value == "" && forma01[cont].value == 0)
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

			      if(campos < 5)
			      {
			        $('#mensaje2').html('Faltan campos por llenar');
			        setTimeout("$('#mensaje2').html('')",5000)
			      }
			      else
			      {
			        document.forma01.action = "salva_productos.php";
			        document.forma01.submit();
			      }
			} 

			function verificacodigo()
			{
			      var id = $('#id_sel').val();
			      var codigo = $('#codigo').val();

			      if(codigo != '')
			      {
			        $.ajax({
			          url : 'Funciones/verificaCodigo.php',
			          type : 'post',
			          dataType : 'text',
			          data : 'id='+id+'&codigo='+codigo,
			          success : function(res)
			          {
			            if(res > 0)
			            {
			              $('#mensaje1').html('El codigo ' +codigo+  ' ya esta registrado');
			              $('#codigo').val('');
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

		<form name="forma01" class = "form1" enctype="multipart/form-data" method="post">
		<label>
			<input id="nombre" type="text" name="nombre"  class = "inputs" placeholder= "Nombre del producto" required>
		</label>
		<br>
		<label>
			<input id="codigo" type="text" name="codigo" class = "inputs" placeholder="Codigo del producto" required onblur="verificacodigo();">
		</label>
		<div id="mensaje1" class = "error"></div>
		<br>
		<label>
			<textarea id = "descripcion" name="descripcion" class = "inputs" placeholder="Descripcion" cols="30" rows="5" required></textarea>
		</label>
		<br>
		<label>
			<input type="number" id = "costo" name="costo" placeholder="Costo" class = "inputs" required>
		</label>
		<br>
		<label>
			<input type="number" id="stock" name="stock" placeholder="Stock" class = "inputs" required>
		</label>
		<h4 align="center" >SELECCIONAR IMAGEN DE PERFIL</h4>	
		<input type="file" id="archivo" name="archivo"><br><br>
		<input onClick="recibe(); return false;" type="submit" value="Registrar" class = "buttons">
		<input type="hidden" id="id_sel" name="id_sel" value="0"/>
		<div id="mensaje2" class = "error2"></div>
	</form>
	</body>
</html>