#include <string.h>
#include <unistd.h>
#include <sys/socket.h>
#include <sys/types.h>
#include <netinet/in.h>
#include <stdlib.h>
#include <stdio.h>

struct Student {
    char student_id[15];
    char subject_id[3][10];
    char fname[15];
    char lname[15];
    char marks[3][3];
    char add[10];
    char dep[10];
    char sem[10];
    char section[5];
};

struct subjects {
    char subject_id[15];
    char subject_name[15];
};

void initializeStudent(struct Student *student, const char *id, const char *sem, const char *section, const char *fname, const char *lname, const char *add, const char *dep, const char *subject_ids[3], const char *marks[3]) {
    strcpy(student->student_id, id);
    strcpy(student->sem, sem);
    strcpy(student->section, section);
    strcpy(student->fname, fname);
    strcpy(student->lname, lname);
    strcpy(student->add, add);
    strcpy(student->dep, dep);

    for (int i = 0; i < 3; i++) {
        strcpy(student->subject_id[i], subject_ids[i]);
        strcpy(student->marks[i], marks[i]);
    }
}

void initializeSubjects(struct subjects *subject, const char *id, const char *name) {
    strcpy(subject->subject_id, id);
    strcpy(subject->subject_name, name);
}

void sendResponse(int ns, const char *response) {
    if (send(ns, response, strlen(response), 0) == -1) {
        printf("\nMessage Sending Failed");
        close(ns);
        exit(0);
    }
}

int main() {
    int s, r, recb, sntb, x, ns, a = 0;
    socklen_t len;
    struct sockaddr_in server, client;
    char buff[200];

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
    printf("\nSocket accepting.");

    struct Student stu[2];
    struct subjects sub[3];

    // Initialize students
    const char *stu1_subject_ids[3] = {"SUBJ1", "SUBJ2", "SUBJ3"};
    const char *stu1_marks[3] = {"85", "75", "88"};
    initializeStudent(&stu[0], "210911310", "5", "C", "John", "Doe", "Address1", "Department1", stu1_subject_ids, stu1_marks);

    const char *stu2_subject_ids[3] = {"SUBJ4", "SUBJ5", "SUBJ6"};
    const char *stu2_marks[3] = {"77", "84", "86"};
    initializeStudent(&stu[1], "210911330", "3", "C", "Jane", "Smith", "Address2", "Department2", stu2_subject_ids, stu2_marks);

    // Initialize subjects
    initializeSubjects(&sub[0], "SUBJ1", "Subject1");
    initializeSubjects(&sub[1], "SUBJ2", "Subject2");
    initializeSubjects(&sub[2], "SUBJ3", "Subject3");

    char PID[5];
    while (1) {
        recb = recv(ns, buff, sizeof(buff), 0);
        if (recb == -1) {
            printf("\nMessage Receiving Failed");
            close(s);
            close(ns);
            exit(0);
        }
        int n, i = 0, j = 0;
        char temp[50];
        int ch = buff[0];
        n = buff[1];
        for (i = 0; i < n; i++) {
            temp[j] = buff[i + 2];
            j++;
        }
        temp[j] = '\0';
        if (ch == 4)
            break;

        int pid = fork();
        if (pid == 0) {
            if (ch == 1) {
                char response[200] = "";

                for (int k = 0; k < 2; k++) {
                    if (strcmp(stu[k].student_id, temp) == 0) {
                        strcat(response, "Name of student is: ");
                        strcat(response, stu[k].fname);
                        strcat(response, " ");
                        strcat(response, stu[k].lname);
                        strcat(response, " ");
                        strcat(response, stu[k].add);
                        strcat(response, " ");
                        strcat(response, stu[k].sem);
                        strcat(response, " ");
                        strcat(response, stu[k].section);
                        strcat(response, " \nPID is: ");
                        sprintf(PID, "%d", getpid());
                        strcat(response, PID);
                        sendResponse(ns, response);
                        break;
                    }
                }

                if (strcmp(response, "") == 0) {
                    sendResponse(ns, "INCORRECT INPUT\n");
                }
            } else if (ch == 2) {
                char response[200] = "";
                for (int k = 0; k < 2; k++) {
                    if (strcmp(stu[k].fname, temp) == 0) {
                        strcat(response, "Dept sem section courses: \n");
                        strcat(response, stu[k].dep);
                        strcat(response, " ");
                        strcat(response, stu[k].sem);
                        strcat(response, stu[k].section);
                        strcat(response, " ");
                        strcat(response, stu[k].subject_id[0]);
                        strcat(response, " ");
                        strcat(response, stu[k].subject_id[1]);
                        strcat(response, " ");
                        strcat(response, stu[k].subject_id[2]);
                        strcat(response, " ");
                        strcat(response, stu[k].sem);
                        strcat(response, " ");
                        strcat(response, stu[k].section);
                        strcat(response, " \nPID is: ");
                        sprintf(PID, "%d", getpid());
                        strcat(response, PID);
                        sendResponse(ns, response);
                        break;
                    }
                }

                if (strcmp(response, "") == 0) {
                    sendResponse(ns, "INCORRECT INPUT\n");
                }
            } else if (ch == 3) {
                char response[200] = "";
                for (int k = 0; k < 2; k++) {
                    for (int l = 0; l < 3; l++) {
                        if (strcmp(stu[k].subject_id[l], temp) == 0) {
                            strcat(response, "Marks are: \n");
                            strcat(response, stu[k].fname);
                            strcat(response, ": ");
                            strcat(response, stu[k].marks[l]);
                            strcat(response, "\n");
                        }
                    }
                }
                if (strcmp(response, "") == 0) {
                    sendResponse(ns, "INCORRECT INPUT\n");
                } else {
                    strcat(response, " \nPID is: ");
                    sprintf(PID, "%d", getpid());
                    strcat(response, PID);
                    sendResponse(ns, response);
                }
            }
            exit(0);
        }
    }

    close(ns);
    close(s);
}
