#include <iostream>
#include <fstream>
#include <vector>
#include <string>

#define STAR1DIGITS 2
#define STAR2DIGITS 12


//get the input
std::vector<std::string> extractInput() {
    std::string line;
    std::vector<std::string> input;
    std::fstream inputFile("input.txt");

    while (std::getline(inputFile, line)) {
        input.push_back(line);
    }
    inputFile.close();

    return input;
}


//Plan:
//find the biggest integer and then check the next biggest integer after that one
int star1() {
    int result = 0;
    std::vector<std::string> input = extractInput();


    for (int i = 0; i < input.size(); i++) {
        int maxIndex = 0;
        int maxValue1 = 0, maxValue2 = 0;

        //find first maximum value
        for (int j = 0; j < input[i].size()-1; j++) {
            if (maxValue1 == 9) break;

            if (input[i][j]-'0' > maxValue1) {
                maxValue1 = input[i][j]-'0';
                maxIndex = j;
            }
        }

        //find maximum value after the first max value
        for (int j = maxIndex+1; j < input[i].size(); j++) {
            if (maxValue2 == 9) break;

            if (input[i][j]-'0' > maxValue2) {
                maxValue2 = input[i][j]-'0';
            }
        }
        result += std::stoi(std::to_string(maxValue1) + std::to_string(maxValue2)); // This is a cool conversion, i like it
        // | 10*maxValue1 + maxValue2 | also works prob better
    }
    return result;
}

int starMultisolver(int digits) {
    int result = 0;
    std::vector<std::string> input = extractInput();

    //Loops THROUGH VECTOR SIZE
    for (int i = 0; i < input.size(); i++) {
        int maxIndex = 0;
        int maxValue = 0;

        //loops THROUG THE STRINGS
        for (int j = 0; j < input[i].size(); j++) {


            //INNER LOOP FOR CHECKING AFTER EACH ELEMENT IS FOUND
            for (int k = maxIndex+1; k < input[i].size()-digits+j; k++) {

            }
        }

    }
    return result;
}

int main() {
    std::cout << "Star 1: " << star1() << "\n";
    return 0;
}