Begin /*A � Recuperaci�n b�sica de datos*/ 

/*1-Recuperar lista de empleados*/

SELECT FIRST_NAME	AS 'Nombre'
	,LAST_NAME		AS 'Apellido'

FROM TEST.EMPLOYEES


/*2-Recuperar id, apellido, fecha de contrataci�n de los empleados*/

SELECT ID
	,LAST_NAME							AS 'Apellido'
	,FORMAT (HIRE_DATE, 'yyyy-MM-dd')	AS 'Fecha de Contratacion'

FROM TEST.EMPLOYEES



/*3-Recuperar id, apellido, fecha de contrataci�n, salario de los empleados.
Tip: notar presencia de valores nulos*/

SELECT ID
	,LAST_NAME							AS 'Apellido'
	,CONVERT(Date, HIRE_DATE)			AS 'Fecha de Contratacion'
	,ISNULL(SALARY, 0)					AS 'Salario'

FROM TEST.EMPLOYEES



/*4-Recuperar id, apellido, fecha de contrataci�n, salario anual de los empleados.
Tip: Calcular el salario anual como 12 veces el salario. Usar alias para el sueldo anual.*/

SELECT ID
	,LAST_NAME							AS 'Apellido'
	,CONVERT(Date, HIRE_DATE)			AS 'Fecha de Contratacion'
	,ISNULL(SALARY*12, 0)				AS 'Salario Anual'

FROM TEST.EMPLOYEES



/*5-Recuperar id, apellido y nombre, fecha de contrataci�n, salario anual de los empleados.
Tip: Concatenar usando ||. Notar que los operadores a usar dependen del tipo de dato de los campos.*/

SELECT ID
	,LAST_NAME +' '+ FIRST_NAME			AS 'Apellido y nombre'
	,CONVERT(Date, HIRE_DATE)			AS 'Fecha de Contratacion'
	,ISNULL(SALARY * 12, 0)				AS 'Salario Anual'

FROM TEST.EMPLOYEES



/*6-Recuperar lista de departamentos que tienen empleados:
6.a- Recuperar lista de departamentos de los empleados*/

SELECT DEPARTMENT_NAME	AS 'Departamentos con empleados'

FROM TEST.DEPARTMENTS dep

INNER JOIN TEST.EMPLOYEES emp
	ON emp.DEPARTMENT_ID = dep.ID


/*6.b- Recuperar lista no repetida de departamentos de los empleados*/

SELECT DEPARTMENT_NAME	AS 'Departamentos con empleados'

FROM TEST.DEPARTMENTS dep

INNER JOIN TEST.EMPLOYEES emp
	ON emp.DEPARTMENT_ID = dep.ID

GROUP BY DEPARTMENT_NAME


END/*Fin seccion A*/

BEGIN /*B � Comparaciones simples y especiales / Comparaciones nulas*/

/*7- Recuperar lista de empleados cuyo departamento sea 10.*/

SELECT emp.FIRST_NAME		AS 'Nombre'
	,emp.LAST_NAME			AS 'Apellido'
	,dep.DEPARTMENT_NAME	AS 'Departamento'
	,dep.ID					AS 'ID_DEPTO'

FROM TEST.EMPLOYEES emp
	,TEST.DEPARTMENTS dep

WHERE emp.DEPARTMENT_ID = 10 
	AND dep.ID = 10


/*8- Recuperar lista de empleados cuyo salario sea menor a 2000.*/

SELECT LAST_NAME	AS 'Apellido'
	,FIRST_NAME		AS 'Nombre'
	,SALARY			AS 'Salario'

FROM TEST.EMPLOYEES

WHERE SALARY < 2000


/*9- Recuperar lista de empleados cuyo salario sea entre 1800 y 3000
Tip: usar cl�usula �between�. Notar diferencia con el uso de 2 condiciones.*/

SELECT LAST_NAME	AS 'Apellido'
	,FIRST_NAME		AS 'Nombre'
	,SALARY			AS 'Salario'

FROM TEST.EMPLOYEES

WHERE SALARY BETWEEN 1800 AND 3000


/*10- Recuperar lista de empleados cuyo departamento sea 10 o 30 o 31.
Tip: usar cl�usula �in�.*/

SELECT LAST_NAME		AS 'Apellido'
	,FIRST_NAME			AS 'Nombre'
	,DEPARTMENT_ID		AS 'ID_Departamento'


FROM TEST.EMPLOYEES emp

WHERE DEPARTMENT_ID IN (10, 30, 31)


/*11- Recuperar lista de empleados cuyo apellido empiece con F.
Tip: usar cl�usula �like�. Notar que los operadores a usar dependen del tipo de dato de los
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


/*13- Recuperar lista de empleados cuyo job_id sea distinto de �AD_CTB�. Tip: Notar
comportamiento de la condici�n con jobs nulos.*/

SELECT LAST_NAME			AS 'Apellido'
	,FIRST_NAME				AS 'Nombre'
	,ISNULL(JOB_ID, 'N/A')	AS 'ID_Trabajo'

FROM TEST.EMPLOYEES

WHERE JOB_ID NOT LIKE 'AD_CTB' 
	OR JOB_ID IS NULL


END/*Fin seccion B*/

BEGIN /*C- Comparaciones con nexos l�gicos / Precedencia de condiciones*/

/*14- Recuperar lista de empleados cuyo job_id sea distinto de �AD_CTB� y cuyo salario sea
mayor a 1900.*/

SELECT FIRST_NAME		AS 'Nombre'
	,LAST_NAME			AS 'Apellido'
	,JOB_ID
	,SALARY				AS 'Salario'

FROM TEST.EMPLOYEES e

WHERE JOB_ID <> 'AD_CTB' 
	AND SALARY > 1900


/*15- Recuperar lista de empleados cuyo job_id sea distinto de �AD_CTB� o cuyo salario sea
mayor a 1900.*/

SELECT FIRST_NAME			AS 'Nombre'
	,LAST_NAME				AS 'Apellido'
	,ISNULL(JOB_ID, 'N/A')	AS 'ID_Trabajo'
	,ISNULL(SALARY, 0)		AS 'Salario'

FROM TEST.EMPLOYEES

WHERE JOB_ID <> 'AD_CTB' 
	OR JOB_ID IS NULL
	OR SALARY > 1900


/*16- Recuperar lista de empleados cuyo job_id sea �AD_CTB� o �FQ_GRT� (sin usar IN) y cuyo
salario sea mayor a 1900.
Tip: Probar precedencia de condiciones con o sin par�ntesis.*/

SELECT LAST_NAME	AS 'Apellido'
	,FIRST_NAME		AS 'Nombre'
	,JOB_ID			AS 'ID_Trabajo'
	,SALARY			AS 'Salario'

FROM TEST.EMPLOYEES

WHERE (JOB_ID = 'AD_CTB' 
	OR JOB_ID = 'FQ_GRT')
	AND SALARY > 1900

END/*Fin seccion C*/

BEGIN /*D- Ordenamiento*/

/*17- Recuperar empleados ordenados por fecha de ingreso (desde m�s viejo a m�s nuevo).*/

SELECT LAST_NAME						AS 'Apellido'
	,FIRST_NAME							AS 'Nombre'
	,CONVERT(date, HIRE_DATE)			AS 'Fecha de ingreso'

FROM TEST.EMPLOYEES

ORDER BY HIRE_DATE 


/*18- Recuperar empleados ordenados por fecha de ingreso (desde m�s nuevo a m�s viejo).*/

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


END /*Fin seccion D*/

BEGIN /*E- Recuperaci�n de datos de m�ltiples tablas*/

/*21- Recuperar lista de empleados con la descripci�n del departamento al que cada uno
pertenece.
Tip: evitar producto cartesiano.
Completar: select * from TEST.EMPLOYEES, �*/

SELECT LAST_NAME											AS 'Apellido'
	,FIRST_NAME												AS 'Nombre'
	,DEPARTMENT_NAME										AS 'Departamento'
	,ISNULL(DEPARTMENT_DESCRIPTION, 'No hay descripcion')	AS 'Descripcion depto.'

FROM TEST.EMPLOYEES e
	,TEST.DEPARTMENTS d

WHERE e.DEPARTMENT_ID = d.ID


/*22- Seleccionar apellido de empleado y nombre de departamento*/

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


/*24- Recuperar lista de empleados con descipci�n de departamentos y ciudades.*/

SELECT LAST_NAME								AS 'Apellido'
	,ISNULL(DEPARTMENT_NAME, 'N/A')				AS 'Departamento'
	,ISNULL(DEPARTMENT_DESCRIPTION, 'N/A')		AS 'Descripcion de depto.'
	,ISNULL(CITY, 'N/A')						AS 'Ciudad'


FROM TEST.LOCATIONS loc

LEFT JOIN TEST.DEPARTMENTS dep
	ON dep.LOCATION_ID = loc.ID

RIGHT JOIN TEST.EMPLOYEES emp
	ON emp.DEPARTMENT_ID = dep.ID


END/*Fin seccion E*/

BEGIN /*F- Uso de cl�usula JOIN*/

/*25- Recuperar lista de empleados con la descripci�n del departamento al que cada uno
pertenece.
Completar: select * from TEST.EMPLOYEES join �*/

SELECT LAST_NAME											AS 'Apellido'
	,FIRST_NAME												AS 'Nombre'
	,DEPARTMENT_NAME										AS 'Departamento'
	,ISNULL(DEPARTMENT_DESCRIPTION, 'No hay descripcion')	AS 'Descripcion depto.'

FROM TEST.EMPLOYEES e

JOIN TEST.DEPARTMENTS d
	ON e.DEPARTMENT_ID = d.ID


/*26- Recuperar lista de empleados con la descripci�n del departamento, tengan o no
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


END/*Fin seccion F*/

BEGIN /*G- Selfjoin*/

/*28- Recuperar lista de subordinados por cada manager*/

SELECT managers.LAST_NAME + ' '
	+managers.FIRST_NAME			AS 'Manager' 
	,subordinados.LAST_NAME +' '
	+subordinados.FIRST_NAME		AS 'Subordinado'


FROM TEST.EMPLOYEES managers
	,TEST.EMPLOYEES subordinados

WHERE subordinados.MANAGER_ID = managers.ID

ORDER BY 'Manager'


END/*Fin seccion G*/

BEGIN /*H- Funciones de agrupamiento*/

/*29- Recuperar m�ximo salario de los empleados.*/

SELECT MAX(SALARY)		AS 'Salario maximo'

FROM TEST.EMPLOYEES


/*30- Recuperar m�ximo, m�nimo, promedio, y suma total de salarios de los empleados.*/

SELECT MAX(SALARY)						AS 'Salario Maximo'
	,MIN(SALARY)						AS 'Salario Minimo'
	,CAST(AVG(SALARY) AS DECIMAL(10,2))	AS 'Salario Promedio'
	,SUM(SALARY)						AS 'Suma Total de Salarios'

FROM TEST.EMPLOYEES


/*31- Recuperar m�ximo, m�nimo, promedio, y suma total de fecha de contrataci�n de los
empleados.
Tip: Notar que las funciones de agrupamiento permitidas dependen del tipo de dato.*/

SELECT CAST(MAX(HIRE_DATE) AS Date)						AS 'Ultima/Max fecha de contratacion'
	,CAST(MIN(HIRE_DATE) AS Date)						AS 'Primera/Min fecha de contratacion'

	,CONVERT(Datetime, AVG(CONVERT(float, HIRE_DATE)))	AS 'Fecha de contratacion promedio'

	,CONVERT(Datetime, SUM(CONVERT(INT,HIRE_DATE)))		AS 'Suma total de fechas'

FROM TEST.EMPLOYEES


/*Notas: El metodo para sumar convierte todas las fechas a entero (dias desde 1900), luego 
se suman entre ellas y se convierte de nuevo a tipo fecha.

Otro metodo intentado fue sumar los a�os con los a�os, los meses con los meses, etc. Pero el mismo generaba 
overflow en los a�os (maximo 9999). Por lo que decidi dejar el metodo explicado previamente. Quizas sea
necesario consultar cual es el resultado esperado de sumar las fechas



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

FULL OUTER JOIN TEST.JOBS j
	ON e.JOB_ID = j.ID

GROUP BY DEPARTMENT_NAME, JOB_NAME

ORDER BY DEPARTMENT_NAME


END/*Fin seccion H*/

BEGIN /*I- Condiciones de grupo*/

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


END/*Fin seccion I*/

BEGIN /*J- Creaci�n de nuevos registros*/

/*38- Crear un nuevo departamento*/


/*38.a- Caso 1: Crear insert de todos los campos en orden.
Tip: Notar restricciones de integridad por padre inexistente y por clave duplicada.
Completar: insert into TEST.DEPARTMENTS VALUES �*/
/*38.b- Caso 2: Crear insert de todos los campos en orden usando valores nulos.
Tip: Notar restricciones de no nulidad.*/
/*38.c- Crear insert usando solamente los campos obligatorios.
Tip: Especificar lista de campos obligatorios.
Completar: insert into TEST.DEPARTMENTS (ID, �*/

END/*Fin seccion J*/

BEGIN/*K- Creaci�n de nuevos registros en base a registros existentes*/

/*39- Crear un nuevo empleado basado en los datos de Gustavo Boulette:
 -cambiando su nombre
 -aumentando su sueldo en $200.
 -blanqueando su manager*/

END/*Fin Seccion K*/

BEGIN/*L- Actualizaci�n de registros*/

/*40- Actualizar salario del empleado 10 a $1100.*/
/*41- Duplicar salario del empleado 11.*/
/*42- Aumentar salario en un 10% a todos los empleados del departamento 40.*/

END/*Fin Seccion L*/

BEGIN/*M- Eliminaci�n de registros*/

/*43- Eliminar departamentos cuyo id sea mayor a 50.
Tip: hacer un select antes y despu�s para verificar usando la misma condici�n que para el
delete.*/
/*44- Eliminar departamento 40.
Tip: notar resultado de las restricciones de integridad.*/

END/*Fin Seccion M*/

BEGIN/*N-Crear una Funci�n*/

/*45- Crear la funci�n &quot;fn_AntiguedadEmpleado&quot; que retorne la antiguedad en a�os de cada
empleado donde el parametro de ingreso es el id del empleado*/

END/*Fin Seccion N*/

BEGIN/*O-Crear un Procedimiento almacenado*/

/*46 - Crear el Procedimiento almacenado &quot;sp_GetNombreAntiguedad&quot; que retorne el primer
nombre y el apellido separados por una coma y en la segunda columna la antiguedad en a�o. Usar
la funci�n creada en el punto anterior.
Ordenar por antiguedad descendiente (mas antiguo primero)*/
END/*Fin Seccion O*/