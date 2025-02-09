%{
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <locale.h>

// Variable global para almacenar el resultado
char* resultado = NULL;

// Función para agregar texto al resultado
void agregarResultado(const char* texto) {
    size_t lenTexto = strlen(texto);
    size_t lenActual = resultado ? strlen(resultado) : 0;

    if (resultado == NULL) {
        resultado = (char*)malloc(lenTexto + 2);
        if (resultado == NULL) return;
        resultado[0] = '\0';
    } else {
        char* temp = (char*)realloc(resultado, lenActual + lenTexto + 2);
        if (temp == NULL) return;
        resultado = temp;
    }

    strcat(resultado, texto);
    strcat(resultado, "\n");
}

// Función que indica el final del análisis
int yywrap() { return 1; }

// Definir funciones de exportación para la DLL en Windows
#ifdef _WIN32
__declspec(dllexport)
#endif
char* analizarLexico(const char* input);

#ifdef _WIN32
__declspec(dllexport)
#endif
void liberarMemoria(char* ptr);
%}

/* ----- DEFINICION DE PATRONES ----- */
%%
"int"       { agregarResultado("TOKEN: Palabra clave -> int"); }
"float"     { agregarResultado("TOKEN: Palabra clave -> float"); }
"if"        { agregarResultado("TOKEN: Palabra clave -> if"); }
"else"      { agregarResultado("TOKEN: Palabra clave -> else"); }
"while"     { agregarResultado("TOKEN: Palabra clave -> while"); }
"return"    { agregarResultado("TOKEN: Palabra clave -> return"); }

[a-zA-Z_][a-zA-Z0-9_]*  { 
    char buffer[256];
    snprintf(buffer, sizeof(buffer), "TOKEN: Identificador -> %s", yytext);
    agregarResultado(buffer);
}

[0-9]+      { 
    char buffer[256];
    snprintf(buffer, sizeof(buffer), "TOKEN: Numero entero -> %s", yytext);
    agregarResultado(buffer);
}

[0-9]+\.[0-9]+  { 
    char buffer[256];
    snprintf(buffer, sizeof(buffer), "TOKEN: Numero decimal -> %s", yytext);
    agregarResultado(buffer);
}

"="         { agregarResultado("TOKEN: Operador de asignacion -> ="); }
"=="        { agregarResultado("TOKEN: Operador de comparacion -> =="); }
"!="        { agregarResultado("TOKEN: Operador de comparacion -> !="); }
"<"         { agregarResultado("TOKEN: Operador menor que -> <"); }
">"         { agregarResultado("TOKEN: Operador mayor que -> >"); }
"<="        { agregarResultado("TOKEN: Operador menor o igual -> <="); }
">="        { agregarResultado("TOKEN: Operador mayor o igual -> >="); }
"+"         { agregarResultado("TOKEN: Operador suma -> +"); }
"-"         { agregarResultado("TOKEN: Operador resta -> -"); }
"*"         { agregarResultado("TOKEN: Operador multiplicacion -> *"); }
"/"         { agregarResultado("TOKEN: Operador division -> /"); }

"&&"        { agregarResultado("TOKEN: Operador logico AND -> &&"); }
"||"        { agregarResultado("TOKEN: Operador logico OR -> ||"); }
"!"         { agregarResultado("TOKEN: Operador logico NOT -> !"); }

";"         { agregarResultado("TOKEN: Punto y coma -> ;"); }
","         { agregarResultado("TOKEN: Coma -> ,"); }
"{"         { agregarResultado("TOKEN: Llave abierta -> {"); }
"}"         { agregarResultado("TOKEN: Llave cerrada -> }"); }
"("         { agregarResultado("TOKEN: Parentesis abierto -> ("); }
")"         { agregarResultado("TOKEN: Parentesis cerrado -> )"); }

\"[^\"]*\"  { 
    char buffer[256];
    snprintf(buffer, sizeof(buffer), "TOKEN: Cadena de texto -> %s", yytext);
    agregarResultado(buffer);
}

[ \t\r\n]+  { /* Ignorar espacios en blanco */ }

.           { 
    char buffer[256];
    snprintf(buffer, sizeof(buffer), "ERROR: Caracter no reconocido -> %s", yytext);
    agregarResultado(buffer);
}

%%

/* ----- IMPLEMENTACIÓN DE FUNCIONES ----- */
char* analizarLexico(const char* input) {
    setlocale(LC_ALL, "C.UTF-8");

    if (resultado) {
        free(resultado);
        resultado = NULL;
    }

    YY_BUFFER_STATE buffer = yy_scan_string(input);
    if (!buffer) return strdup("ERROR: No se pudo analizar la entrada.");

    yylex();
    yy_delete_buffer(buffer);

    return resultado ? strdup(resultado) : strdup("ERROR: No se encontraron tokens.");
}

void liberarMemoria(char* ptr) {
    if (ptr) {
        free(ptr);
    }
}

