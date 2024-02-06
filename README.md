# Descripción del proyecto
El proyecto trata de una página web que muestra una amplia variedad de actividades turísticas disponibles en diversos países.
Esta página utiliza la api de [Viator](https://docs.viator.com/partner-api/technical/) para proporcionar la información sobre dichas activividades.

# Tecnologías utilizadas
- Api rest
- C#
- .Net
- Html
- Javascript
- Git/GitHub
- Microsoft sql server

# Bibliotecas usadas
| Biblioteca             | Descripción                                                                                                                                                                                                                      | Usado para             
|------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------|
|  HttpClient            | Se utiliza para enviar solicitudes HTTP y recibir respuestas HTTP de un recurso identificado por un URI. Está pensado para crear instancias una vez y reutilizarse durante toda la vida de una aplicación.                       | Consumir api             |
| IMemoryCache           | Representa una abstracción de una memoria caché en la que se puede almacenar datos temporalmente para mejorar el rendimiento de la aplicación. Proporciona métodos para agregar, recuperar y eliminar datos de la memoria caché. | Guardar datos en cache   |
| XUnit                  |                                                                                                                                                                                                                                  |                          |
| NSubstitute            |                                                                                                                                                                                                                                  |                          |
| RichardSzalay.MockHttp |

# Setup
- Instalar [.net Core SDK](https://dotnet.microsoft.com/es-es/download/dotnet/3.1)
- Clonar el repositorio
- Desde el CMD entrar a la carpeta del repositorio
 
  `C:/Viator-Activities/`
- Ejecutar el comando:
  
  `dotnet run`
- Copiar la url y pegarla en el navegador

![image](https://github.com/Camixx/Viator-Activities/assets/66759199/3e1d8c6e-9fbf-4406-956b-93f4845bdad9)




# Endpoints
### `/destinations?name={destinationName}`
### Response:
```json
[
  {
    "destinationId":25907,
    "destinationName":"Arad"
  }
]
```

### `/activities?destinationId={destinationId}`
### Response:
```json 
[
  {
    "productCode":"268155P68",
    "title":"Arad to Bucharest - Private Guided Transfer - Car and Driver",
    "description":"Just let us know the time and the place from where we should pick you up!\n\nOUR SERVICE GUARANTEES:\n• Discretion \n• Useful tips and information regarding any activities you have planned \n• Flexibility \n\nIt should not surprise you that with us you get a private driver whose only purpose is to make your trip memorable, in a positive way :)",
    "image":"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-720x480/0a/e4/59/da.jpg",
    "pricing":564.41,
    "productUrl":"https://shop.live.rc.viator.com/tours/Arad/Private-Guided-Transfer-from-Arad-to-Bucharest/d25907-268155P68?mcid=42383&pid=P00128232&medium=api&api_version=2.0",
    "destinationId":25907,
    "rating":0.0
  },
  {
    "productCode":"268155P68",
    "title":"Arad to Bucharest - Private Guided Transfer - Car and Driver",
    "description":"Just let us know the time and the place from where we should pick you up!\n\nOUR SERVICE GUARANTEES:\n• Discretion \n• Useful tips and information regarding any activities you have planned \n• Flexibility \n\nIt should not surprise you that with us you get a private driver whose only purpose is to make your trip memorable, in a positive way :)",
    "image":"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-720x480/0a/e4/59/da.jpg",
    "pricing":564.41,
    "productUrl":"https://shop.live.rc.viator.com/tours/Arad/Private-Guided-Transfer-from-Arad-to-Bucharest/d25907-268155P68?mcid=42383&pid=P00128232&medium=api&api_version=2.0",
    "destinationId":25907,
    "rating":0.0
  },
  {
    "productCode":"268155P68",
    "title":"Arad to Bucharest - Private Guided Transfer - Car and Driver",
    "description":"Just let us know the time and the place from where we should pick you up!\n\nOUR SERVICE GUARANTEES:\n• Discretion \n• Useful tips and information regarding any activities you have planned \n• Flexibility \n\nIt should not surprise you that with us you get a private driver whose only purpose is to make your trip memorable, in a positive way :)",
    "image":"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-720x480/0a/e4/59/da.jpg",
    "pricing":564.41,
    "productUrl":"https://shop.live.rc.viator.com/tours/Arad/Private-Guided-Transfer-from-Arad-to-Bucharest/d25907-268155P68?mcid=42383&pid=P00128232&medium=api&api_version=2.0",
    "destinationId":25907,
    "rating":0.0
  },
  {
    "productCode":"268155P68",
    "title":"Arad to Bucharest - Private Guided Transfer - Car and Driver",
    "description":"Just let us know the time and the place from where we should pick you up!\n\nOUR SERVICE GUARANTEES:\n• Discretion \n• Useful tips and information regarding any activities you have planned \n• Flexibility \n\nIt should not surprise you that with us you get a private driver whose only purpose is to make your trip memorable, in a positive way :)",
    "image":"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-720x480/0a/e4/59/da.jpg",
    "pricing":564.41,
    "productUrl":"https://shop.live.rc.viator.com/tours/Arad/Private-Guided-Transfer-from-Arad-to-Bucharest/d25907-268155P68?mcid=42383&pid=P00128232&medium=api&api_version=2.0",
    "destinationId":25907,
    "rating":0.0
  }
]
```

