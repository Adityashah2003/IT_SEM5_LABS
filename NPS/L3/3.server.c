#include <string.h>
#include <unistd.h>
#include <sys/socket.h>
#include <sys/types.h>
#include <netinet/in.h>
#include <stdlib.h>
#include <stdio.h>

int main() {
  int s, r, recb, sntb, ns, a = 0;
  char buff[50], buff2[50];
  socklen_t len;
  struct sockaddr_in server, client;
  s = socket(AF_INET, SOCK_STREAM, 0);
  if (s == -1) {
    printf("\nSocket creation error.");
    exit(0);
  }
  printf("\nSocket created.");
  server.sin_family = AF_INET;
  server.sin_port = htons(3388);
  server.sin_addr.s_addr = htonl(INADDR_ANY);
  r = bind(s, (struct sockaddr *)&server, sizeof(server));
  if (r == -1) {
    printf("\nBinding error.");
    exit(0);
  }
  printf("\nSocket binded.");
  r = listen(s, 1);
  if (r == -1) {
    close(s);
    exit(0);
  }
  printf("\nSocket listening.");
  len = sizeof(client);
  ns = accept(s, (struct sockaddr *)&client, &len);
  if (ns == -1) {
    close(s);
    exit(0);
  }
  printf("\nSocket accepting.\n");
  recb = recv(ns, buff, sizeof(buff), 0);
  if (recb == -1) {
    printf("\nMessage Receiving Failed");
    close(s);
    close(ns);
    exit(0);
  }
  printf("\nMessage Received: ");
  printf("%s\n", buff);
  int n = strlen(buff);
  char num[50] = {0}, alpha[50] = {0};
  int i, j = 0, k = 0;
  for (i = 0; i < n; i++) {
    if ((buff[i] >= 65 && buff[i] <= 90) || (buff[i] >= 97 && buff[i] <= 122)) {
      alpha[j] = buff[i];
      j++;
    } else {
      num[k] = buff[i];
      k++;
    }
  }
  alpha[j] = '\0';
  num[k] = '\0';
  int pid = fork();
  if (pid > 0) {
    // parent
    for (i = 0; i < j - 1; i++) {
      for (int x = 0; x < j - i - 1; x++) {
        if (alpha[x] > alpha[x + 1]) {
          char temp = alpha[x];
          alpha[x] = alpha[x + 1];
          alpha[x + 1] = temp;
        }
      }
    }
    printf("\nParent process - Sorted alphabetical string is:  \n");
    printf("%s\n", alpha);
    printf("\n\n");
    sntb = send(ns, alpha, strlen(alpha), 0);
    if (sntb == -1) {
      close(s);
      printf("\nMessage Sending Failed");
      exit(0);
    }
  } else if (pid == 0) {
    // child
    for (i = 0; i < k - 1; i++) {
      for (int x = 0; x < k - i - 1; x++) {
        if (num[x] > num[x + 1]) {
          char temp = num[x];
          num[x] = num[x + 1];
          num[x + 1] = temp;
        }
      }
    }
    printf("\nChild process - Sorted numerical string is:  \n");
    printf("%s\n", num);
    printf("\n\n");
    sntb = send(ns, num, strlen(num), 0);
    if (sntb == -1) {
      close(s);
      printf("\nMessage Sending Failed");
      exit(0);
    }
  }
  close(ns);
  close(s);
}
