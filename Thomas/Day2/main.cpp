#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <sstream>
#include <regex>
#include <chrono>
#include <iomanip>
//get input
std::string extractInput() {
    std::string input;
    std::ifstream inputFile;
    inputFile.open("input");
    inputFile >> input;
    inputFile.close();
    return input;
}
//convert input to numbers
std::vector<long long> getAllNumbers(std::string input) {
    std::vector<long long> allNumbers;
    long long num1, num2;
    char dash;
    std::string range;

    std::stringstream ss(input);
    while (std::getline(ss, range, ',')) {
        std::stringstream ssR(range);

        ssR >> num1 >> dash >> num2;

        allNumbers.push_back(num1);
        allNumbers.push_back(num2);
    }

    return allNumbers;
}

bool isNumInvalid(long long num) {
    bool result = false;

    std::string strNum = std::to_string(num);

    if (strNum.length() % 2 == 1) {return false;}

    std::string subStr1 = strNum.substr(0, strNum.length() / 2);
    std::string subStr2 = strNum.substr(strNum.length()  / 2);

    if (subStr1 == subStr2){result = true;}
    else {result = false;}

    return result;
}

//pick the invalid IDs and return them added up
long long addInvalidIDs(std::vector<long long> allNumbers) {
    long long result = 0;
    std::vector<long long> realAllNumbers;
    realAllNumbers.reserve(1800000);

    for (int i = 0; i < allNumbers.size(); ++i) {
        int j = 0;
        if (i % 2 == 1) {
            while (allNumbers[i-1]+j <= allNumbers[i]) {
                realAllNumbers.push_back(allNumbers[i-1]+j);
                j++;
            }
        }
    }


    for (int i = 0; i < realAllNumbers.size(); ++i) {
        if (isNumInvalid(realAllNumbers[i])) {
            result += realAllNumbers[i];
        }
    }

    return result;
}

long long addInvalidIDs2(std::vector<long long> allNumbers) {
    std::regex invalid(R"(^(?:([0-9]+))\1+$)");
    long long result = 0;
    std::vector<long long> realAllNumbers;

    for (int i = 0; i < allNumbers.size(); ++i) {
        int j = 0;
        if (i % 2 == 1) {
            while (allNumbers[i-1]+j <= allNumbers[i]) {
                realAllNumbers.push_back(allNumbers[i-1]+j);
                j++;
            }
        }
    }


    for (long long num : realAllNumbers) {
        std::string s = std::to_string(num);

        if (std::regex_match(s, invalid)) {
            result += num;
        }
    }

    return result;
}


long long star1() {

    std::vector<long long> allNumbers;
    std::string input =  extractInput();
    allNumbers = getAllNumbers(input);

    return addInvalidIDs(allNumbers);
}

long long star2() {

    std::vector<long long> allNumbers;
    std::string input =  extractInput();
    allNumbers = getAllNumbers(input);

    return addInvalidIDs2(allNumbers);
}

int main() {
    using clock = std::chrono::high_resolution_clock;

    auto start1 = clock::now();
    long long r1 = star1();
    auto end1 = clock::now();

    std::chrono::duration<double> diff1 = end1 - start1;

    std::cout << "Star 1: " << r1 << "  ("
              << std::fixed << std::setprecision(1)
              << diff1.count() << "s)\n";


    auto start2 = clock::now();
    long long r2 = star2();
    auto end2 = clock::now();

    std::chrono::duration<double> diff2 = end2 - start2;

    std::cout << "Star 2: " << r2 << "  ("
              << std::fixed << std::setprecision(1)
              << diff2.count() << "s)\n";

    //VERY BAD TIME BRUH
    return 0;
}
