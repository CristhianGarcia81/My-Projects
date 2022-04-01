<?php
	define("HOST", 'localhost');
	define("BD", 'cliente01');
	define("USER_BD", 'root');
	define("PASS_BD", 'root');

	function conecta()
	{
		if(!($con = mysql_connect(HOST,USER_BD,PASS_BD)))
		{
			echo "Error conectando al servidor de BBDD";
			exit();
		}

		if(!mysql_select_db(BD,$con))
		{
			echo "Error seleccionando BD";
			exit();
		}
		return $con;
	}
	$con = conecta();

    $lienzo = imagecreatetruecolor(800, 1000);
    
    // Asignar colores
    $blanco = imagecolorallocate($lienzo, 255, 255, 255);
    $rosa = imagecolorallocate($lienzo, 255, 105, 180);
    $verde = imagecolorallocate($lienzo, 132, 135, 28);
    $gris = imagecolorallocate($lienzo, 64, 64, 64);
    $morado = imagecolorallocate($lienzo, 34, 13, 39);
    $azul = imagecolorallocate($lienzo, 0, 0, 255);
    $negro = imagecolorallocate($lienzo, 0, 0, 0);
    // Inicializa el fondo del lienzo a blanco	
	imagefill($lienzo, 0, 0, $blanco);
    // Dibujar tres rectángulos, cada uno con su color
	imagerectangle($lienzo, 100, 450, 110, 600, $azul);
    imagerectangle($lienzo, 90, 400, 100, 600, $morado);
    imagerectangle($lienzo, 80, 375, 90, 600, $rosa);
    imagerectangle($lienzo, 60, 350, 70, 600, $verde);
    imagerectangle($lienzo, 40, 100, 50, 600, $gris);
    imageline($lienzo, 5, 100, 5, 600, $negro);
    imageline($lienzo, 5, 600, 130, 600, $negro);


    imagerectangle($lienzo, 460, 420, 400, 410, $azul);
    imagerectangle($lienzo, 480, 440, 400, 430, $morado);
    imagerectangle($lienzo, 510, 460, 400, 450, $rosa);
    imagerectangle($lienzo, 600, 480, 400, 470, $verde);
    imagerectangle($lienzo, 700, 500, 400, 490, $gris);
    imageline($lienzo, 700, 510, 400, 510, $negro);
    imageline($lienzo, 400, 390, 400, 510, $negro);

    imageellipse($lienzo, 100, 917, 10, 10, $azul);
    imageellipse($lienzo, 80, 912, 10, 10, $morado);
    imageellipse($lienzo, 60, 910, 10, 10, $rosa);
    imageellipse($lienzo, 40, 900, 10, 10, $verde);
    imageellipse($lienzo, 20, 700, 10, 10, $gris);
    imageline($lienzo, 10, 927, 150, 927, $negro);
    imageline($lienzo, 10, 930, 10, 650, $negro);

    imagerectangle($lienzo, 400, 900, 390, 650, $gris);
	imagerectangle($lienzo, 420, 900, 410, 800, $gris);
	imagerectangle($lienzo, 440, 900, 430, 870, $gris);
	imagerectangle($lienzo, 460, 900, 450, 875, $gris);
	imagerectangle($lienzo, 480, 900, 470, 880, $gris);
	imageline($lienzo, 350, 900, 350, 620, $negro);
    imageline($lienzo, 600, 900, 350, 900, $negro);
    // Imprimir y liberar memoria
    header('Content-Type: image/jpeg');
    
    imagejpeg($lienzo);
    imagedestroy($lienzo);
?>