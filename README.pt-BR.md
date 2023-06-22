<div align="center">
  <img src="https://github.com/H4x0rModdz/RansomSharp/raw/main/RansomSharp_logo.png" alt="Logo do Projeto" width="200">

  # RansomSharp

  Um Ransomware didático para fins educacionais.

  ![GitHub](https://img.shields.io/github/license/H4x0rModdz/RansomSharp.svg)

  > "Educação é a arma mais poderosa que você pode usar para mudar o mundo." - Nelson Mandela

  <!-- Imagem ou GIF demonstrando o funcionamento do projeto -->

  ![Demonstração do RansomSharp](https://github.com/H4x0rModdz/RansomSharp/raw/main/demo.gif)


  ## Sobre o Ransomware

  Um ransomware é um tipo de malware que criptografa arquivos em um sistema e exige um resgate (geralmente em criptomoedas) para desbloquear e recuperar os arquivos. É importante ressaltar que o RansomSharp foi criado apenas para fins educacionais e não deve ser utilizado de forma indevida. A utilização de ransomwares fora do seu propósito educacional, ou seja, para fins lucrativos ou prejudiciais a outras pessoas é `ILEGAL` e `ANTIÉTICA`.

  ## Funcionalidades

  - Criptografa o arquivo `test.txt` dentro da pasta `RansomSharp` criada na área de trabalho do usuário.
  - Altera o papel de parede do sistema para um wallpaper personalizado.
  - Gera uma chave de criptografia aleatória para cada execução.
  - Exige um resgate, representado pela chave de criptografia, para descriptografar os arquivos.
  - Fornece a opção de inserir a chave de criptografia correta para recuperar os arquivos.

  ## Como funciona

  O RansomSharp é desenvolvido em C# e utiliza o algoritmo de criptografia simétrica AES (Advanced Encryption Standard) para criptografar e descriptografar o arquivo `test.txt`. O programa gera uma chave de criptografia aleatória, criptografa o conteúdo do arquivo e armazena a chave em um segundo arquivo chamado `dontworry.txt`.

  Além disso, o programa faz o download de um wallpaper personalizado a partir de uma URL fornecida e define-o como papel de parede do sistema.

  Quando o programa é executado, exibe uma mensagem ao usuário informando que seus arquivos foram criptografados e solicita o pagamento de um resgate para recuperá-los. Se o usuário inserir a chave de criptografia correta, o programa descriptografa o arquivo `test.txt`, substituindo o conteúdo criptografado pelo conteúdo original.

  É importante ressaltar que o programa não é persistente e não se propaga automaticamente. Ele é apenas uma demonstração para fins educacionais.

  ## Instalação

  1. Clone este repositório em sua máquina local.
  2. Certifique-se de ter o .NET Framework instalado em sua máquina.
  3. Abra o arquivo `RansomSharp.sln` em seu IDE preferido.
  4. Compile e execute o projeto.

  ## Contribuição

  Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue para relatar bugs, sugerir novas funcionalidades ou enviar um pull request com melhorias para o projeto.

  ## Licença

  Este projeto é licenciado nos termos da licença [GPLv3](LICENSE). Leia o arquivo LICENSE para obter mais informações.

  **Nota:** Este projeto é fornecido apenas para fins educacionais. Não me responsabilizo por qualquer uso indevido do código.

  ## Créditos

  Desenvolvido por [Lucas Lobo(H4x0rModdz)](https://github.com/H4x0rModdz)

</div>
