import json
import sys

query = 'insert into tjd (num_dolg, date_okaz_uslug, gruz, stan_otpr, stan_nazn, date_otpr, num_nakl, kol_vag, kol_tonn, ' +\
    'cen_tonn, sum_bez_nds, sum_nds, sum_s_nds, num_act) values'

input_data = sys.stdin.readline()
input_data = input_data.replace("'", '"')
results = json.loads(input_data)

valuesQuery = []

for i in len(results[num_dog]):
    valueQuery = "(" + results["num_dog"] + ", " + results["date_usl"] + ", '" + results["gruz"] + \
        "', '" + results["stan_otpr"] + "', '" + results["stan_nazn"] + "', " + results["date_otpr"] + \
        ", '" + results["num_nakl"] + "', " + results["kol_vag"] + ", " + results["kol_ton"] + \
        ", " + results["cen_ton"] + ", " + results["sumbeznds"] + ", " + results["sumnds"] + \
        ", " + results["sumsnds"] + ", '" + results["numact"] + "')"

    valuesQuery.append(valueQuery)

query += (", ").join(valuesQuery)

print(query)