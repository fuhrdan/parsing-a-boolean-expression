//*****************************************************************************
//** 1106. Parsing a Boolean Expression    leetcode                          **
//*****************************************************************************


bool parse(const char* expression, int* i)
{
    if (expression[*i] != '&' && expression[*i] != '|' && expression[*i] != '!')
    {
        bool result = expression[*i] == 't';
        (*i)++;
        return result;
    }

    char op = expression[*i];
    *i += 2;  // Skip the operator and the opening parenthesis
    bool stk[100];  // Stack for storing parsed results (assuming a maximum size of 100)
    int stk_index = 0;

    while (expression[*i] != ')')
    {
        if (expression[*i] == ',')
        {
            (*i)++;
            continue;
        }
        stk[stk_index++] = parse(expression, i);  // Recursively parse the expression
    }

    (*i)++;  // Skip the closing parenthesis

    if (op == '&')
    {
        for (int j = 0; j < stk_index; ++j)
        {
            if (!stk[j]) return false;
        }
        return true;
    }

    if (op == '|')
    {
        for (int j = 0; j < stk_index; ++j)
        {
            if (stk[j]) return true;
        }
        return false;
    }

    // Operator is '!'
    return !stk[0];
}

bool parseBoolExpr(char* expression) {
    int i = 0;
    return parse(expression, &i); 
}