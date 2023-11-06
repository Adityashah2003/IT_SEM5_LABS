#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <sys/socket.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <fcntl.h>
#define MAXSIZE 100

int main(){
    int s, n, r;
    int sent,rev;
    struct sockaddr_in server,client;

    s = socket(AF_INET,SOCK_STREAM,0);
    if(s==-1)
	    printf("\nSocket creation error");
    
    server.sin_family = AF_INET;
    server.sin_port = htons(3388);
    server.sin_addr.s_addr= inet_addr(INADDR_ANY);

    r = bind(s,(struct sockaddr*)&server,sizeof(server));
    if(r==1){
        printf("Binding error");
        close(sockfd);
	}

    r = listen(s,1);
    if(retval==-1)
	    close(sockfd);

    n = accept(s,(struct sockaddr*)&client,sizeof(client));
    int pid = fork();
    char buff[50];
    char buff2[50];
    while(1){
        if(pid>0){
            printf( "Parent Process, PID : %d && PPID : %d\n" ,getpid() , getppid( )) ;
            scanf("%s",buff);
            sent=send(n,buff,sizeof(buff),0);
        }
        else if(pid==0){
            printf( "Child Process, PID : %d && PPID : %d\n" ,getpid() , getppid( )) ;
            rev = recv(n,buff2,sizeof(buff2),0);
            printf("%s\n", buff2);
        }
    }
    close(n);
    close(s);
}

