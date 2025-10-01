// inicializamos datos
int horas_laboradas = 0;
int precio_hora = 0;
string tipo_empleado = ""; 
int salario = 0, operarios = 0, tecnicos = 0, profesionales = 0;
float salario_final = 0.0f, aumento = 0f, deduccion = 0f, salario_neto_operarios = 0f, salario_neto_tecnicos = 0f, salario_neto_profesionales = 0f, porcentaje_deduccion = 0.0f;
string cedula = "";
string nombre = "";
string nombre_empleado = "";
void solicitar_datos()
{
    Console.WriteLine("Ingrese su numero de cedula: ");
    cedula = Console.ReadLine();
    Console.WriteLine("Ingrese su nombre completo: ");
    nombre = Console.ReadLine();
    Console.WriteLine("Ingrese la cantidad de horas laboradas: ");
    horas_laboradas = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el precio por hora: ");
    precio_hora = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el tipo de empleado:");
    Console.WriteLine("1-Operario 2-Técnico 3-Profesional");
    tipo_empleado = (Console.ReadLine());
}
void menu()
{
    switch (tipo_empleado)
    {
        case "1":
            operarios++;
            porcentaje_deduccion = 0.15f;
            operaciones(horas_laboradas, precio_hora, tipo_empleado);
            salario_neto_operarios += salario_final;
             nombre_empleado = "Operario";
            break;
    
        case "2":
            tecnicos++;
            porcentaje_deduccion = 0.10f;
            operaciones(horas_laboradas, precio_hora, tipo_empleado);
            salario_neto_tecnicos += salario_final;
            nombre_empleado = "Técnico";
            break;
        case "3":
            profesionales++;
            porcentaje_deduccion = 0.05f;
            operaciones(horas_laboradas, precio_hora, tipo_empleado); 
            salario_neto_profesionales += salario_final;
            nombre_empleado = "Profesional";
            break;
        default:
            Console.WriteLine("Tipo de empleado no válido.");
            break;
    }
}
void operaciones(int horas_laboradas, int precio_hora, string tipo_empleado)
{
    salario = horas_laboradas * precio_hora;
    aumento = salario * porcentaje_deduccion;
    deduccion = salario * 9.17f / 100;
    salario_final = salario + aumento - deduccion;
}
void mostrar_resultados_individuales()
{
    Console.WriteLine($"•\tCedula:{cedula}\r\n•\tNombre Empleado:{nombre}\r\n•\tTipo Empleado:{nombre_empleado}\r\n•\tSalario por Hora:{precio_hora}\r\n•\tCantidad de Horas:{horas_laboradas}\r\n•\tSalario Ordinario:{salario}\r\n•\tAumento:{aumento}\r\n•\tSalario Bruto:{salario+aumento}\r\n•\tDeducción CCSS:{deduccion}\r\n•\tSalario Neto:{salario_final}\r\n");
}
void mostrar_resultados_totales()
{
    Console.WriteLine($"•\tTotal Salario Neto Operarios: {salario_neto_operarios}\r\n•\tTotal Salario Neto Técnicos: {salario_neto_tecnicos}\r\n•\tTotal Salario Neto Profesionales: {salario_neto_profesionales}\r\n");
    Console.WriteLine($"Con un total de {operarios} operarios, {tecnicos} tecnicos y {profesionales} profesionales");
    Console.WriteLine($"El promedio del salario neto de los operarios es de {salario_neto_operarios/operarios}");
    Console.WriteLine($"El promedio del salario neto de los tecnicos es de {salario_neto_tecnicos/tecnicos}");
    Console.WriteLine($"El promedio del salario neto de los profesionales es de {salario_neto_profesionales/profesionales}");
}
Boolean salida = true;
void main()
{
    do 
        {
            solicitar_datos();
            menu();
        Console.Clear();
        mostrar_resultados_individuales();
        Console.WriteLine("¿Desea ingresar otro empleado? (s/n)");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() != "s")
            {
                salida = false;
            }
        } while (salida);
}
main();
Console.Clear();
mostrar_resultados_totales();