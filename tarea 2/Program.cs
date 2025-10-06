int cantidad_empleados = 100;
string[] cedulas = new string[cantidad_empleados];
string[] nombres = new string[cantidad_empleados];
int[] horas_laboradas = new int[cantidad_empleados];
int[] precio_hora = new int[cantidad_empleados];
string[] tipo_empleado = new string[cantidad_empleados];
string[] nombre_empleado = new string[cantidad_empleados];
int[] salario = new int[cantidad_empleados];
float[] aumento = new float[cantidad_empleados];
float[] deduccion = new float[cantidad_empleados];
float[] salario_final = new float[cantidad_empleados];

int operarios = 0, tecnicos = 0, profesionales = 0;
float salario_neto_operarios = 0f, salario_neto_tecnicos = 0f, salario_neto_profesionales = 0f;

int contador = 0;
Boolean salida = true;

void solicitar_datos(int i)
{
    Console.WriteLine("Ingrese su numero de cedula: ");
    cedulas[i] = Console.ReadLine();
    Console.WriteLine("Ingrese su nombre completo: ");
    nombres[i] = Console.ReadLine();
    Console.WriteLine("Ingrese la cantidad de horas laboradas: ");
    horas_laboradas[i] = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el precio por hora: ");
    precio_hora[i] = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el tipo de empleado:");
    Console.WriteLine("1-Operario 2-Técnico 3-Profesional");
    tipo_empleado[i] = Console.ReadLine();
}

void menu(int i)
{
    float porcentaje_deduccion = 0f;
    switch (tipo_empleado[i])
    {
        case "1":
            operarios++;
            porcentaje_deduccion = 0.15f;
            nombre_empleado[i] = "Operario";
            break;
        case "2":
            tecnicos++;
            porcentaje_deduccion = 0.10f;
            nombre_empleado[i] = "Técnico";
            break;
        case "3":
            profesionales++;
            porcentaje_deduccion = 0.05f;
            nombre_empleado[i] = "Profesional";
            break;
        default:
            Console.WriteLine("Tipo de empleado no válido.");
            return;
    }
    operaciones(i, porcentaje_deduccion);
}

void operaciones(int i, float porcentaje_deduccion)
{
    salario[i] = horas_laboradas[i] * precio_hora[i];
    aumento[i] = salario[i] * porcentaje_deduccion;
    deduccion[i] = salario[i] * 9.17f / 100;
    salario_final[i] = salario[i] + aumento[i] - deduccion[i];

    switch (tipo_empleado[i])
    {
        case "1":
            salario_neto_operarios += salario_final[i];
            break;
        case "2":
            salario_neto_tecnicos += salario_final[i];
            break;
        case "3":
            salario_neto_profesionales += salario_final[i];
            break;
    }
}

void mostrar_resultados_individuales(int i)
{
    Console.WriteLine($"•\tCedula:{cedulas[i]}\r\n•\tNombre Empleado:{nombres[i]}\r\n•\tTipo Empleado:{nombre_empleado[i]}\r\n•\tSalario por Hora:{precio_hora[i]}\r\n•\tCantidad de Horas:{horas_laboradas[i]}\r\n•\tSalario Ordinario:{salario[i]}\r\n•\tAumento:{aumento[i]}\r\n•\tSalario Bruto:{salario[i] + aumento[i]}\r\n•\tDeducción CCSS:{deduccion[i]}\r\n•\tSalario Neto:{salario_final[i]}\r\n");
}

void mostrar_resultados_totales()
{
    Console.WriteLine($"•\tTotal Salario Neto Operarios: {salario_neto_operarios}\r\n•\tTotal Salario Neto Técnicos: {salario_neto_tecnicos}\r\n•\tTotal Salario Neto Profesionales: {salario_neto_profesionales}\r\n");
    Console.WriteLine($"Con un total de {operarios} operarios, {tecnicos} tecnicos y {profesionales} profesionales");

    if (operarios > 0)
        Console.WriteLine($"El promedio del salario neto de los operarios es de {salario_neto_operarios / operarios}");
    if (tecnicos > 0)
        Console.WriteLine($"El promedio del salario neto de los tecnicos es de {salario_neto_tecnicos / tecnicos}");
    if (profesionales > 0)
        Console.WriteLine($"El promedio del salario neto de los profesionales es de {salario_neto_profesionales / profesionales}");
}

void main()
{
    do
    {
        solicitar_datos(contador);
        menu(contador);
        Console.Clear();
        mostrar_resultados_individuales(contador);
        contador++;
        Console.WriteLine("¿Desea ingresar otro empleado? (s/n)");
        string respuesta = Console.ReadLine();
        if (respuesta.ToLower() != "s")
        {
            salida = false;
        }
    } while (salida && contador < cantidad_empleados);
}

main();
Console.Clear();
mostrar_resultados_totales();
