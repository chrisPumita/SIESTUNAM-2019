Proceso siestunam
	// Definiciendo el acceso al sistema
	Definir user,pass,coches Como Caracter;
	Definir placaIn Como Caracter;
	Definir tam,i,cont Como Entero;
	tam <- 6;
	Dimension coches[tam];
	// DE LOS COCHES REGISTRADOS
	coches[1] <- 'MCK906';
	coches[2] <- 'HFK4895';
	coches[3] <- 'P68UPC';
	coches[4] <- 'J66AAW';
	coches[5] <- 'MHK9202';
	Escribir 'Ingrese usuario';
	Leer user;
	Escribir 'Ingrese password';
	Leer pass;
	Si user='usuario' Y pass='1234' Entonces
		Escribir 'BIENVENIDO AL SISTEMA';
		Escribir 'Ingrese placa';
		Leer placaIn;
		cont <- 1;
		Para i<-1 Hasta tam-1 Hacer
			Si placaIn=coches[i] Entonces
				cont <- 1;
			FinSi
		FinPara
		// Verificando si encontro la placa
		Si cont>=1 Entonces
			Escribir 'ACCESO PERIMITIDO';
			Escribir 'REGISTRANDO ENTARDA';
		SiNo
			Escribir 'NO ESTA REGISTRADO EL VEHICULO, REGISTRELO';
		FinSi
	SiNo
		Escribir 'ERROR DE USUARIO, USUARIO NO REGISTRADO';
	FinSi
FinProceso
