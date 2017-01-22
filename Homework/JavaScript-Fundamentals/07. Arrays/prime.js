function solve(args) {

    let n = +args[0];
    let biggestPrime = 2;
    // http://introcs.cs.princeton.edu/java/14array/PrimeSieve.java.html
    // initially assume all integers are prime

    // undefined serve as true
    let isPrime = new Array(n + 1);

    // mark non-primes <= n using Sieve of Eratosthenes


    for (let factor = 2; factor * factor <= n; factor += 1) {
        // if factor is prime, then mark multiples of factor as nonprime
        // suffices to consider mutiples factor, factor+1, ...,  n/factor
        if (isPrime[factor] === undefined) {
            for (let j = factor; factor * j <= n; j += 1) {
                isPrime[factor * j] = false;
            }
        }
    }

    // count primes
    let primes = 0;
    for (let i = 2; i <= n; i++) {
        if (isPrime[i] === undefined) {
            biggestPrime = i;
        }
    }

    console.log(biggestPrime);
}