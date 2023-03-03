int contem(char str1[], char str2[]) //METODO QUE COMPARA PALAVRAS EM TEXTOS
        {
          int n = 0;
          for (int i = 0; str1[i] != '\0'; i++) 
          {
            int achou = 1;
            for(int j = 0; str2[j]!='\0';j++)
            {
              if (str1[i+j] != str2[j]) 
              {
                achou =0;
                break;
              }
            }
            if(achou){n++;}
          }
            
                return n;
         }

