/*TP4 - Nociones SQL - Practica
Autor: Ignacio Torres
Fecha: 29/04/2021
Contacto: Torres.Ignacio.TI@gmail.com*/


/*A – Recuperación básica de datos*/ 
/*1-Recuperar lista de empleados*/

SELECT FIRST_NAME	AS 'Nombre'
	,LAST_NAME		AS 'Apellido'

FROM TEST.EMPLOYEES


/*2-Recuperar id, apellido, fecha de contratación de los empleados*/

SELECT ID
	,LAST_NAME							AS 'Apellido'
	,FORMAT (HIRE_DATE, 'yyyy-MM-dd')	AS 'Fecha de Contratacion'

FROM TEST.EMPLOYEES



/*3-Recuperar id, apellido, fecha de contratación, salario de los empleados.
Tip: notar presencia de valores nulos*/

SELECT ID
	,LAST_NAME							AS 'Apellido'
	,CONVERT(Date, HIRE_DATE)			AS 'Fecha de Contratacion'
	,ISNULL(SALARY, 0)					AS 'Salario'

FROM TEST.EMPLOYEES



/*4-Recuperar id, apellido, fecha de contratación, salario anual de los empleados.
Tip: Calcular el salario anual como 12 veces el salario. Usar alias para el sueldo anual.*/

SELECT ID
	,LAST_NAME							AS 'Apellido'
	,CONVERT(Date, HIRE_DATE)			AS 'Fecha de Contratacion'
	,ISNULL(SALARY*12, 0)				AS 'Salario Anual'

FROM TEST.EMPLOYEES



/*5-Recuperar id, apellido y nombre, fecha de contratación, salario anual de los empleados.
Tip: Concatenar usando ||. Notar que los operadores a usar dependen del tipo de dato de los campos.*/

SELECT ID
	,LAST_NAME +' '+ FIRST_NAME			AS 'Apellido y nombre'
	,CONVERT(Date, HIRE_DATE)			AS 'Fecha de Contratacion'
	,ISNULL(SALARY * 12, 0)				AS 'Salario Anual'

FROM TEST.EMPLOYEES



/*6-Recuperar lista de departamentos que tienen empleados:
6.a- Recuperar lista de departamentos de los empleados*/

SELECT DEPARTMENT_NAME		AS 'Departamentos con empleados'

FROM TEST.DEPARTMENTS dep
	INNER JOIN TEST.EMPLOYEES emp
		ON emp.DEPARTMENT_ID = dep.ID


/*6.b- Recuperar lista no repetida de departamentos de los empleados*/

SELECT DEPARTMENT_NAME		AS 'Departamentos con empleados'

FROM TEST.DEPARTMENTS dep
	INNER JOIN TEST.EMPLOYEES emp
		ON emp.DEPARTMENT_ID = dep.ID

GROUP BY DEPARTMENT_NAME


/*B – Comparaciones simples y especiales / Comparaciones nulas*/
/*7- Recuperar lista de empleados cuyo departamento sea 10.*/

SELECT FIRST_NAME		AS 'Nombre'
	,LAST_NAME			AS 'Apellido'
	,DEPARTMENT_ID		AS 'ID_Departamento'

FROM TEST.EMPLOYEES

WHERE DEPARTMENT_ID = 10


/*8- Recuperar lista de empleados cuyo salario sea menor a 2000.*/

SELECT LAST_NAME	AS 'Apellido'
	,FIRST_NAME		AS 'Nombre'
	,SALARY			AS 'Salario'

FROM TEST.EMPLOYEES

WHERE SALARY < 2000


/*9- Recuperar lista de empleados cuyo salario sea entre 1800 y 3000
Tip: usar cláusula “between”. Notar diferencia con el uso de 2 condiciones.*/

SELECT LAST_NAME	AS 'Apellido'
	,FIRST_NAME		AS 'Nombre'
	,SALARY			AS 'Salario'

FROM TEST.EMPLOYEES

WHERE SALARY BETWEEN 1800 AND 3000


/*10- Recuperar lista de empleados cuyo departamento sea 10 o 30 o 31.
Tip: usar cláusula “in”.*/

SELECT LAST_NAME		AS 'Apellido'
	,FIRST_NAME			AS 'Nombre'
	,DEPARTMENT_ID		AS 'ID_Departamento'


FROM TEST.EMPLOYEES emp

WHERE DEPARTMENT_ID IN (10, 30, 31)


/*11- Recuperar lista de empleados cuyo apellido empiece con F.
Tip: usar cláusula “like”. Notar que los operadores a usar dependen del tipo de dato de los
campos.*/

SELECT LAST_NAME	AS 'Apellido'
	,FIRST_NAME		AS 'Nombre'

FROM TEST.EMPLOYEES

WHERE LAST_NAME LIKE 'F%'


/*12- Recuperar lista de empleados cuyo job_id:*/
/*12.a- no haya sido definido*/

SELECT LAST_NAME			AS 'Apellido'
	,FIRST_NAME				AS 'Nombre'
	,JOB_ID = 'No definido'	

FROM TEST.EMPLOYEES

WHERE JOB_ID IS NULL


/*12.b- haya sido definido.*/

SELECT LAST_NAME			AS 'Apellido'
	,FIRST_NAME				AS 'Nombre'
	,JOB_ID

FROM TEST.EMPLOYEES

WHERE JOB_ID IS NOT NULL


/*13- Recuperar lista de empleados cuyo job_id sea distinto de ‘AD_CTB’. Tip: Notar
comportamiento de la condición con jobs nulos.*/

SELECT LAST_NAME			AS 'Apellido'
	,FIRST_NAME				AS 'Nombre'
	,ISNULL(JOB_ID, 'N/A')	AS 'ID_Trabajo'

FROM TEST.EMPLOYEES

WHERE JOB_ID NOT LIKE 'AD_CTB' 
	OR JOB_ID IS NULL


/*C- Comparaciones con nexos lógicos / Precedencia de condiciones*/
/*14- Recuperar lista de empleados cuyo job_id sea distinto de ‘AD_CTB’ y cuyo salario sea
mayor a 1900.*/

SELECT FIRST_NAME		AS 'Nombre'
	,LAST_NAME			AS 'Apellido'
	,JOB_ID
	,SALARY				AS 'Salario'

FROM TEST.EMPLOYEES e

WHERE JOB_ID <> 'AD_CTB' 
	AND SALARY > 1900


/*15- Recuperar lista de empleados cuyo job_id sea distinto de ‘AD_CTB’ o cuyo salario sea
mayor a 1900.*/

SELECT FIRST_NAME			AS 'Nombre'
	,LAST_NAME				AS 'Apellido'
	,ISNULL(JOB_ID, 'N/A')	AS 'ID_Trabajo'
	,ISNULL(SALARY, 0)		AS 'Salario'

FROM TEST.EMPLOYEES

WHERE JOB_ID <> 'AD_CTB' 
	OR JOB_ID IS NULL
	OR SALARY > 1900


/*16- Recuperar lista de empleados cuyo job_id sea ‘AD_CTB’ o ‘FQ_GRT’ (sin usar IN) y cuyo
salario sea mayor a 1900.
Tip: Probar precedencia de condiciones con o sin paréntesis.*/

SELECT LAST_NAME	AS 'Apellido'
	,FIRST_NAME		AS 'Nombre'
	,JOB_ID			AS 'ID_Trabajo'
	,SALARY			AS 'Salario'

FROM TEST.EMPLOYEES

WHERE (JOB_ID = 'AD_CTB' 
	OR JOB_ID = 'FQ_GRT')
	AND SALARY > 1900

/*D- Ordenamiento*/
/*17- Recuperar empleados ordenados por fecha de ingreso (desde más viejo a más nuevo).*/

SELECT LAST_NAME						AS 'Apellido'
	,FIRST_NAME							AS 'Nombre'
	,CONVERT(date, HIRE_DATE)			AS 'Fecha de ingreso'

FROM TEST.EMPLOYEES

ORDER BY HIRE_DATE 


/*18- Recuperar empleados ordenados por fecha de ingreso (desde más nuevo a más viejo).*/

SELECT LAST_NAME						AS 'Apellido'
	,FIRST_NAME							AS 'Nombre'
	,CONVERT(date, HIRE_DATE)			AS 'Fecha de ingreso'

FROM TEST.EMPLOYEES

ORDER BY HIRE_DATE DESC


/*19- Recuperar empleados ordenados por fecha de ingreso descendente y apellido ascendente.*/

SELECT LAST_NAME						AS 'Apellido'
	,FIRST_NAME							AS 'Nombre'
	,CONVERT(date, HIRE_DATE)			AS 'Fecha de ingreso'

FROM TEST.EMPLOYEES

ORDER BY HIRE_DATE DESC
	,LAST_NAME


/*20- Recuperar apellido y salario anual de empleados ordenados por salario anual.
Tip: Usar alias de columna para ordenar por salario anual.*/

SELECT LAST_NAME					AS 'Apellido'
	,ISNULL(SALARY*12, 0)			AS 'Salario Anual'

FROM TEST.EMPLOYEES

ORDER BY 'Salario Anual' DESC


/*E- Recuperación de datos de múltiples tablas*/
/*21- Recuperar lista de empleados con la descripción del departamento al que cada uno
pertenece.
Tip: evitar producto cartesiano.
Completar: select * from TEST.EMPLOYEES, …*/

SELECT LAST_NAME											AS 'Apellido'
	,FIRST_NAME												AS 'Nombre'
	,ISNULL(DEPARTMENT_DESCRIPTION, 'No hay descripcion')	AS 'Descripcion depto.'

FROM TEST.EMPLOYEES e
	,TEST.DEPARTMENTS d

WHERE e.DEPARTMENT_ID = d.ID


/*22- Seleccionar apellido de empleado y nombre de departamento*/
/*Nota: Interprete que los ejercicios 22, 23 y 24 piden toda la informacion de cada columna,
independientemente de si se relaciona con otra tabla o no. Pero decidi usar un full outer join en
lugar de multiples froms para evitar repetir informacion.*/

SELECT ISNULL(LAST_NAME, 'N/A')			AS 'Apellido'
	,ISNULL(DEPARTMENT_NAME, 'N/A')		AS 'Departamento'

FROM TEST.EMPLOYEES e
	FULL OUTER JOIN TEST.DEPARTMENTS d
		ON e.DEPARTMENT_ID = d.ID


/*23- Agregar id de empleado y id de departamento
Tip: desambiguar campos usando alias de tablas.*/

SELECT ISNULL(LAST_NAME, 'N/A')			AS 'Apellido'
	,ISNULL(DEPARTMENT_NAME, 'N/A')		AS 'Departamento'
	,ISNULL(e.ID, -1)					AS 'ID de empleado'
	,ISNULL(d.ID, -1)					AS 'ID de depto.'

FROM TEST.EMPLOYEES e
	FULL OUTER JOIN TEST.DEPARTMENTS d
		ON e.DEPARTMENT_ID = d.ID


/*24- Recuperar lista de empleados con descipción de departamentos y ciudades.*/

SELECT LAST_NAME								AS 'Apellido'
	,ISNULL(DEPARTMENT_DESCRIPTION, 'N/A')		AS 'Descripcion de departamento'
	,ISNULL(CITY, 'N/A')						AS 'Ciudad'

FROM TEST.LOCATIONS loc
	FULL OUTER JOIN TEST.DEPARTMENTS dep
		ON dep.LOCATION_ID = loc.ID
	FULL OUTER JOIN TEST.EMPLOYEES emp
		ON emp.DEPARTMENT_ID = dep.ID


/*F- Uso de cláusula JOIN*/
/*25- Recuperar lista de empleados con la descripción del departamento al que cada uno
pertenece.
Completar: select * from TEST.EMPLOYEES join …*/

SELECT LAST_NAME											AS 'Apellido'
	,FIRST_NAME												AS 'Nombre'
	,DEPARTMENT_NAME										AS 'Departamento'
	,ISNULL(DEPARTMENT_DESCRIPTION, 'No hay descripcion')	AS 'Descripcion depto.'

FROM TEST.EMPLOYEES e
	JOIN TEST.DEPARTMENTS d
		ON e.DEPARTMENT_ID = d.ID


/*26- Recuperar lista de empleados con la descripción del departamento, tengan o no
departamento asignado.*/

SELECT LAST_NAME											AS 'Apellido'
	,FIRST_NAME												AS 'Nombre'
	,ISNULL(DEPARTMENT_NAME, 'N/A')							AS 'Departamento'
	,ISNULL(DEPARTMENT_DESCRIPTION, 'No hay descripcion')	AS 'Descripcion depto.'

FROM TEST.DEPARTMENTS d
	RIGHT JOIN TEST.EMPLOYEES e
		ON d.ID = e.DEPARTMENT_ID


/*27- Recuperar lista de departamentos con empleados de cada departamento, tengan o no
empleados asociados.*/

SELECT DEPARTMENT_NAME										AS 'Departamento'
	,ISNULL(DEPARTMENT_DESCRIPTION, 'No hay descripcion')	AS 'Descripcion depto.'
	,ISNULL(LAST_NAME +' '+ FIRST_NAME, 'No hay personal')	AS 'Empleado'

FROM TEST.DEPARTMENTS d
	LEFT JOIN TEST.EMPLOYEES e
		ON d.ID = e.DEPARTMENT_ID


/*G- Selfjoin*/
/*28- Recuperar lista de subordinados por cada manager*/

SELECT managers.LAST_NAME + ' '
	+managers.FIRST_NAME			AS 'Manager' 
	,subordinados.LAST_NAME +' '
	+subordinados.FIRST_NAME		AS 'Subordinado'

FROM TEST.EMPLOYEES managers
	,TEST.EMPLOYEES subordinados

WHERE subordinados.MANAGER_ID = managers.ID

ORDER BY 'Manager'


/*H- Funciones de agrupamiento*/
/*29- Recuperar máximo salario de los empleados.*/

SELECT MAX(SALARY)		AS 'Salario maximo'

FROM TEST.EMPLOYEES


/*30- Recuperar máximo, mínimo, promedio, y suma total de salarios de los empleados.*/

SELECT MAX(SALARY)						AS 'Salario Maximo'
	,MIN(SALARY)						AS 'Salario Minimo'
	,CAST(AVG(SALARY) AS DECIMAL(10,2))	AS 'Salario Promedio'
	,SUM(SALARY)						AS 'Suma Total de Salarios'

FROM TEST.EMPLOYEES


/*31- Recuperar máximo, mínimo, promedio, y suma total de fecha de contratación de los
empleados.
Tip: Notar que las funciones de agrupamiento permitidas dependen del tipo de dato.*/

SELECT CAST(MAX(HIRE_DATE) AS Date)						AS 'Ultima/Max fecha de contratacion'
	,CAST(MIN(HIRE_DATE) AS Date)						AS 'Primera/Min fecha de contratacion'
	,CONVERT(Datetime, AVG(CONVERT(float, HIRE_DATE)))	AS 'Fecha de contratacion promedio'
	,CONVERT(Datetime, SUM(CONVERT(INT,HIRE_DATE)))		AS 'Suma total de fechas'

FROM TEST.EMPLOYEES

/*Nota: Otro metodo intentado fue sumar los años con los años, los meses con los meses, etc. Pero el mismo generaba 
overflow en los años (maximo 9999). Por lo que decidi dejar el metodo de convertir las fechas a dias desde 1900 y 
sumarlas. Quizas sea necesario consultar cual es el resultado esperado de sumar las fechas*/


/*32- Obtener la cantidad de empleados.*/

SELECT	COUNT(ID) AS 'Empleados totales'

FROM TEST.EMPLOYEES


/*33- Obtener la cantidad de empleados cuyo departamento sea 10.*/

SELECT	COUNT(ID) AS 'Empleados en departamento 10'

FROM TEST.EMPLOYEES

WHERE DEPARTMENT_ID = 10


/*34- Obtener la cantidad de empleados de cada departamento.*/

SELECT DEPARTMENT_NAME	AS 'Departamento' 
	,COUNT(e.ID)		AS 'Empleados'	

FROM TEST.DEPARTMENTS d
	LEFT JOIN TEST.EMPLOYEES e
		ON e.DEPARTMENT_ID = d.ID

GROUP BY DEPARTMENT_NAME


/*35- Obtener la cantidad de empleados por cada departamento y job.*/

SELECT DEPARTMENT_NAME			AS 'Departamento' 
	,ISNULL(JOB_NAME, 'N/A')	AS 'Trabajo'	
	,COUNT(e.ID)				AS 'Empleados'	
		

FROM TEST.DEPARTMENTS d
	LEFT JOIN TEST.EMPLOYEES e
		ON e.DEPARTMENT_ID = d.ID
	LEFT JOIN TEST.JOBS j
		ON e.JOB_ID = j.ID

GROUP BY DEPARTMENT_NAME, JOB_NAME


/*I- Condiciones de grupo*/
/*36- Recuperar los departamentos y el salario promedio de cada departamento.*/

SELECT DEPARTMENT_NAME									AS 'Departamento'
	,CAST(AVG(SALARY) AS decimal(10,2))					AS 'Salario Promedio'

FROM TEST.DEPARTMENTS d
	LEFT JOIN TEST.EMPLOYEES e
		ON e.DEPARTMENT_ID = d.ID

GROUP BY DEPARTMENT_NAME

HAVING AVG(SALARY) IS NOT NULL


/*37- Recuperar los departamentos y el salario promedio si es menor a 1200.*/

SELECT DEPARTMENT_NAME									AS 'Departamento'
	,CAST(AVG(SALARY) AS decimal(10,2))					AS 'Salario Promedio'

FROM TEST.DEPARTMENTS d
	LEFT JOIN TEST.EMPLOYEES e
		ON e.DEPARTMENT_ID = d.ID

GROUP BY DEPARTMENT_NAME

HAVING AVG(SALARY) < 1200 
	AND AVG(SALARY) IS NOT NULL

SELECT * FROM TEST.EMPLOYEES


/*J- Creación de nuevos registros*/
/*38- Crear un nuevo departamento*/
/*38.a- Caso 1: Crear insert de todos los campos en orden.
Tip: Notar restricciones de integridad por padre inexistente y por clave duplicada.
Completar: insert into TEST.DEPARTMENTS VALUES …*/

BEGIN TRANSACTION
	INSERT INTO TEST.DEPARTMENTS
	VALUES (60,'No definido',3,DEFAULT)
COMMIT


/*38.b- Caso 2: Crear insert de todos los campos en orden usando valores nulos.
Tip: Notar restricciones de no nulidad.*/

INSERT INTO TEST.DEPARTMENTS
VALUES (NULL,NULL,NULL,NULL)

/*Nota: Dara error debido a que hay campos que no aceptan valores nulos, se corrige dandole valores a esos campos obligatorios*/


/*38.c- Crear insert usando solamente los campos obligatorios.
Tip: Especificar lista de campos obligatorios.
Completar: insert into TEST.DEPARTMENTS (ID, …*/

BEGIN TRANSACTION
	INSERT INTO TEST.DEPARTMENTS (ID, LOCATION_ID, DEPARTMENT_NAME)
	VALUES (70, 3, 'No definido')
COMMIT


/*K- Creación de nuevos registros en base a registros existentes*/
/*39- Crear un nuevo empleado basado en los datos de Gustavo Boulette:
 -cambiando su nombre
 -aumentando su sueldo en $200.
 -blanqueando su manager*/


BEGIN TRANSACTION
	INSERT INTO TEST.EMPLOYEES (ID, SALARY, DEPARTMENT_ID, JOB_ID, HIRE_DATE, FIRST_NAME,LAST_NAME)
	
	SELECT	(
				SELECT MAX(ID)+1
				FROM TEST.EMPLOYEES
			)
			,SALARY + 200
			,DEPARTMENT_ID
			,JOB_ID
			,HIRE_DATE
			,'Luis Alberto'
			,'Spinetta'

			FROM TEST.EMPLOYEES

			WHERE FIRST_NAME = 'Gustavo'
				AND LAST_NAME = 'Boulette'
COMMIT


/*L- Actualización de registros*/
/*40- Actualizar salario del empleado 10 a $1100.*/

BEGIN TRANSACTION
	UPDATE TEST.EMPLOYEES
	SET SALARY = 1100
	WHERE ID = 10
COMMIT


/*41- Duplicar salario del empleado 11.*/

BEGIN TRANSACTION
	UPDATE TEST.EMPLOYEES
	SET SALARY = SALARY * 2
	WHERE ID = 11
COMMIT


/*42- Aumentar salario en un 10% a todos los empleados del departamento 40.*/

BEGIN TRANSACTION
	UPDATE TEST.EMPLOYEES
	SET SALARY = SALARY * 1.10
	WHERE DEPARTMENT_ID = 40
COMMIT


/*M- Eliminación de registros*/
/*43- Eliminar departamentos cuyo id sea mayor a 50.
Tip: hacer un select antes y después para verificar usando la misma condición que para el
delete.*/

BEGIN TRANSACTION
	SELECT DEPARTMENT_NAME
		,ID
	FROM TEST.DEPARTMENTS
	WHERE ID > 50

	DELETE FROM TEST.DEPARTMENTS
	WHERE ID > 50

	SELECT DEPARTMENT_NAME
		,ID
	FROM TEST.DEPARTMENTS
	WHERE ID > 50	
COMMIT


/*44- Eliminar departamento 40.
Tip: notar resultado de las restricciones de integridad.*/

BEGIN TRANSACTION
	/*Se muestra lo que sera borrado*/
	SELECT DEPARTMENT_NAME
		,dep.ID					AS 'ID_Departamento'
		,emp.ID					AS 'ID_Empleado'

	FROM TEST.DEPARTMENTS dep
		LEFT JOIN TEST.EMPLOYEES emp
			ON emp.DEPARTMENT_ID = dep.ID

	WHERE dep.ID = 40

	/*Se deslinkea a empleados de departamento 40*/
	UPDATE TEST.EMPLOYEES
	SET	DEPARTMENT_ID = NULL
	WHERE DEPARTMENT_ID = 40

	/*Se borra departamento*/
	DELETE FROM TEST.DEPARTMENTS
	WHERE ID = 40

	/*Verificacion de cambios*/
	SELECT DEPARTMENT_NAME
		,dep.ID					AS 'ID_Departamento'
		,emp.ID					AS 'ID_Empleado'

	FROM TEST.DEPARTMENTS dep
		LEFT JOIN TEST.EMPLOYEES emp
			ON emp.DEPARTMENT_ID = dep.ID

	WHERE dep.ID = 40
ROLLBACK

/*Nota: Para borrar departamento 40 es necesario deslinkear a los empleados en TEST.EMPLOYEES
que tengan a ese departamento en su DEPARTMENT_ID. No comiteo el delete porque 
no estoy seguro de que se haya pedido deslinkear a los empleados*/


/*N-Crear una Función*/
/*45- Crear la función &quot;fn_AntiguedadEmpleado&quot; que retorne la antiguedad en años de cada
empleado donde el parametro de ingreso es el id del empleado*/

DROP FUNCTION dbo.fn_AntiguedadEmpleado
GO
CREATE FUNCTION fn_AntiguedadEmpleado(@id int)
RETURNS int
AS
BEGIN
	DECLARE @Antiguedad int
	SELECT @Antiguedad = CONVERT(INT, DATEDIFF(DAY, HIRE_DATE, CURRENT_TIMESTAMP)/365.25)
	FROM TEST.EMPLOYEES WHERE id=@id
	RETURN @Antiguedad
END
GO


/*O-Crear un Procedimiento almacenado*/

/*46 - Crear el Procedimiento almacenado &quot;sp_GetNombreAntiguedad&quot; que retorne el primer
nombre y el apellido separados por una coma y en la segunda columna la antiguedad en año. Usar
la función creada en el punto anterior.
Ordenar por antiguedad descendiente (mas antiguo primero)*/

DROP PROCEDURE dbo.sp_GetNombreAntiguedad
GO
CREATE PROCEDURE sp_GetNombreAntiguedad
AS
	SELECT First_name +', '+Last_Name		AS 'Empleado'
		,dbo.fn_AntiguedadEmpleado(ID)		AS 'Antiguedad'
	FROM[TEST].[EMPLOYEES] 
	ORDER BY 'Antiguedad' DESC
GO

EXEC dbo.sp_GetNombreAntiguedad

