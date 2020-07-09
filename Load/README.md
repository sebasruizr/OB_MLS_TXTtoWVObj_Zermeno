### Supuestos

1. Todos loa archivos tienen encabezado.
1. Los archivos deben tener la misma cantidad de columns (en header y renglón) que las configuradas
1. Un renglón válido debe contener exactamente el mismo número de columnas que el encabezado **configurado**, no el que obtuvo del archivo.
1. Si un renglón es inválido, todo el anexo es inválido
1. Si un renglón tiene todos sus campos vacíos, es inválido
1. Si el archivo sólo contiene encabezado y un renglón con todos los valores vaciós, se debe notificar, sin embago no se hace nada con él
1. Si el atributo no existe en WV, se reporta un error



### Nombre de archivo = Anexo

numAuditoria_nombreAuditoria_nombreObservación.txt

Lv1 Auditoria
Lv2 Observación
Lv3 Registros (el archivo es anexo)


Auditoria hasta 5 docs que tienen una clase cada uno y se clsifican en 3 categorias:
    Acta de arqueo
    Inventario sucursal
    Inventario almoneda
    
Hay como 60 tipos de observaciones



Referencia del archivo de excel

Pestaña: TipoAnexo por Documento -> Representa la estructura jerárquica
Row




Si no encuentro clase error
Si no encuentro la auditoria Error (se busca con audit num)
Si no encuentro la observación se contruye
    num audit
    
 si no hay un atributo en WV error
 
    
    



