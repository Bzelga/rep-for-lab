#include <math.h>
#include <time.h>

struct Input
{
    int m;
};
   
struct Output
{
    double absolute_time;
    double relative_time;
};

void FoundPi(struct Input* S1, struct Output* S2)
{
    
    struct timespec start, end;
    
    double pi = 3.0, n, absolute_time, relative_time;
    
    clock_gettime(CLOCK_MONOTONIC_RAW, &start);
    
    for(n = 1.0; n < S1->m; n++)
    {
        pi += 4.0 * (pow(-1.0, n+1)) / (2*n * (2*n+1) * (2*n + 2));
    }
    
    clock_gettime(CLOCK_MONOTONIC_RAW, &end);
    
    S2->absolute_time = end.tv_sec-start.tv_sec + 0.000000001*(end.tv_nsec-start.tv_nsec);
    
    S2->relative_time = 0.000000001 / S2->absolute_time * 100;
    
    //printf("pi = %.20f\nTImeTaken: %lf sec.\nRelative inaccuracy: %.20lf\n", pi, S2.absolute_time, S2.relative_time);
    
}
