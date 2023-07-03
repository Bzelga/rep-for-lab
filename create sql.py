import json
import sys

query = 'insert into tjd (num_dolg, date_okaz_uslug, gruz, stan_otpr, stan_nazn, date_otpr, num_nakl, kol_vag, kol_tonn, ' +\
    'cen_tonn, sum_bez_nds, sum_nds, sum_s_nds, num_act) values'

input_data = sys.stdin.readline()
input_data = input_data.replace("'", '"')
results = json.loads(input_data)

valuesQuery = []

for i in range(0,len(results['num_dog'])):
    valueQuery = "(" + results["num_dog"][i] + ", " + results["date_usl"][i] + ", '" + results["gruz"][i] + \
        "', '" + results["stan_otpr"][i] + "', '" + results["stan_nazn"][i] + "', " + results["date_otpr"][i] + \
        ", '" + results["num_nakl"][i] + "', " + results["kol_vag"][i] + ", " + results["kol_ton"][i] + \
        ", " + results["cen_ton"][i] + ", " + results["sumbeznds"][i] + ", " + results["sumnds"][i] + \
        ", " + results["sumsnds"][i] + ", '" + results["numact"][i] + "')"

    valuesQuery.append(valueQuery)

query += (", ").join(valuesQuery)

print(query)