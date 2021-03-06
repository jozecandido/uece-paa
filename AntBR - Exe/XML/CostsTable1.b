<?xml version="1.0" encoding="utf-8" ?>
<!--
XML de Configuração dos custos de viagem (trip) e estadia (stay) entre as
cidades-sede dos clubes do campeonato brasileiro de 2006,
-->
<costs>
  <!--
  Fatores de multiplicação para valores de hospedagem e estadia,
  Ex: 25 membros do clube,
  -->
  <matches_sequence_number>
    <matches name="away" value="3"/>
    <matches name="home" value="3"/>
  </matches_sequence_number>
  <multiplication_factors>
    <trip_factor value="35"/>
    <stay_factor value="27"/>
  </multiplication_factors>
  <!--
  Custos de viagem e estadia relaciondados a uma determinada cidade,
  -->
  <cities>
    <city name="Belo Horizonte">
      <trip_costs>
        <destination name="Belo Horizonte" value="0,001"/>
        <destination name="Campinas" value="664,92"/>
        <destination name="Caxias do Sul" value="553,92"/>
        <destination name="Curitiba" value="494,92"/>
        <destination name="Florianópolis" value="554,92"/>
        <destination name="Fortaleza" value="784,92"/>
        <destination name="Goiânia" value="474,92"/>
        <destination name="Porto Alegre" value="654,92"/>
        <destination name="Recife" value="624,92"/>
        <destination name="Rio de Janeiro" value="114,92"/>
        <destination name="São Paulo" value="240,0"/>
        <destination name="Santos" value="279,7"/>
        <destination name="São Caetano do Sul" value="288,6"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
    <city name="Campinas">
      <trip_costs>
        <destination name="Belo Horizonte" value="664,92"/>
        <destination name="Campinas" value="0,001"/>
        <destination name="Caxias do Sul" value="420,7"/>
        <destination name="Curitiba" value="414,92"/>
        <destination name="Florianópolis" value="304,92"/>
        <destination name="Fortaleza" value="754,92"/>
        <destination name="Goiânia" value="274,92"/>
        <destination name="Porto Alegre" value="594,92"/>
        <destination name="Recife" value="834,92"/>
        <destination name="Rio de Janeiro" value="274,92"/>
        <destination name="São Paulo" value="114,92"/>
        <destination name="Santos" value="154,62"/>
        <destination name="São Caetano do Sul" value="163,52"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
    <city name="Caxias do Sul">
      <trip_costs>
        <destination name="Belo Horizonte" value="553,92"/>
        <destination name="Campinas" value="420,7"/>
        <destination name="Caxias do Sul" value="2,1"/>
        <destination name="Curitiba" value="601,08"/>
        <destination name="Florianópolis" value="741,08"/>
        <destination name="Fortaleza" value="1421,08"/>
        <destination name="Goiânia" value="570,08"/>
        <destination name="Porto Alegre" value="811,08"/>
        <destination name="Recife" value="991,08"/>
        <destination name="Rio de Janeiro" value="520,08"/>
        <destination name="São Paulo" value="350,08"/>
        <destination name="Santos" value="389,78"/>
        <destination name="São Caetano do Sul" value="398,68"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
    <city name="Curitiba">
      <trip_costs>
        <destination name="Belo Horizonte" value="494,92"/>
        <destination name="Campinas" value="414,92"/>
        <destination name="Caxias do Sul" value="601,08"/>
        <destination name="Curitiba" value="0,001"/>
        <destination name="Florianópolis" value="799,12"/>
        <destination name="Fortaleza" value="875,00"/>
        <destination name="Goiânia" value="519,12"/>
        <destination name="Porto Alegre" value="418,08"/>
        <destination name="Recife" value="705,00"/>
        <destination name="Rio de Janeiro" value="320"/>
        <destination name="São Paulo" value="289,12"/>
        <destination name="Santos" value="328,82"/>
        <destination name="São Caetano do Sul" value="337,72"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
    <city name="Florianópolis">
      <trip_costs>
        <destination name="Belo Horizonte" value="554,92"/>
        <destination name="Campinas" value="304,92"/>
        <destination name="Caxias do Sul" value="741,08"/>
        <destination name="Curitiba" value="799,12"/>
        <destination name="Florianópolis" value="0,001"/>
        <destination name="Fortaleza" value="780,00"/>
        <destination name="Goiânia" value="535,00"/>
        <destination name="Porto Alegre" value="185,00"/>
        <destination name="Recife" value="735,00"/>
        <destination name="Rio de Janeiro" value="440"/>
        <destination name="São Paulo" value="440,00"/>
        <destination name="Santos" value="479,7"/>
        <destination name="São Caetano do Sul" value="488,6"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
    <city name="Fortaleza">
      <trip_costs>
        <destination name="Belo Horizonte" value="784,92"/>
        <destination name="Campinas" value="754,92"/>
        <destination name="Caxias do Sul" value="1421,08"/>
        <destination name="Curitiba" value="875,00"/>
        <destination name="Florianópolis" value="780,00"/>
        <destination name="Fortaleza" value="0,001"/>
        <destination name="Goiânia" value="619"/>
        <destination name="Porto Alegre" value="980"/>
        <destination name="Recife" value="109,00"/>
        <destination name="Rio de Janeiro" value="570,00"/>
        <destination name="São Paulo" value="379,12"/>
        <destination name="Santos" value="418,82"/>
        <destination name="São Caetano do Sul" value="427,72"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
    <city name="Goiânia">
      <trip_costs>
        <destination name="Belo Horizonte" value="474,92"/>
        <destination name="Campinas" value="274,92"/>
        <destination name="Caxias do Sul" value="570,08"/>
        <destination name="Curitiba" value="519,12"/>
        <destination name="Florianópolis" value="535,00"/>
        <destination name="Fortaleza" value="619"/>
        <destination name="Goiânia" value="0,001"/>
        <destination name="Porto Alegre" value="555,00"/>
        <destination name="Recife" value="710"/>
        <destination name="Rio de Janeiro" value="455,00"/>
        <destination name="São Paulo" value="250"/>
        <destination name="Santos" value="289,7"/>
        <destination name="São Caetano do Sul" value="298,6"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
    <city name="Porto Alegre">
      <trip_costs>
        <destination name="Belo Horizonte" value="654,92"/>
        <destination name="Campinas" value="594,92"/>
        <destination name="Caxias do Sul" value="811,08"/>
        <destination name="Curitiba" value="418,08"/>
        <destination name="Florianópolis" value="185,00"/>
        <destination name="Fortaleza" value="980"/>
        <destination name="Goiânia" value="555,00"/>
        <destination name="Porto Alegre" value="0,001"/>
        <destination name="Recife" value="845"/>
        <destination name="Rio de Janeiro" value="410,00"/>
        <destination name="São Paulo" value="425"/>
        <destination name="Santos" value="464,7"/>
        <destination name="São Caetano do Sul" value="473,6"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
    <city name="Recife">
      <trip_costs>
        <destination name="Belo Horizonte" value="624,92"/>
        <destination name="Campinas" value="834,92"/>
        <destination name="Caxias do Sul" value="991,08"/>
        <destination name="Curitiba" value="705,00"/>
        <destination name="Florianópolis" value="735,00"/>
        <destination name="Fortaleza" value="109,00"/>
        <destination name="Goiânia" value="710"/>
        <destination name="Porto Alegre" value="845"/>
        <destination name="Recife" value="0,001"/>
        <destination name="Rio de Janeiro" value="670,00"/>
        <destination name="São Paulo" value="319,12"/>
        <destination name="Santos" value="358,82"/>
        <destination name="São Caetano do Sul" value="367,72"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
    <city name="Rio de Janeiro">
      <trip_costs>
        <destination name="Belo Horizonte" value="114,92"/>
        <destination name="Campinas" value="274,92"/>
        <destination name="Caxias do Sul" value="520,08"/>
        <destination name="Curitiba" value="320"/>
        <destination name="Florianópolis" value="440"/>
        <destination name="Fortaleza" value="570,00"/>
        <destination name="Goiânia" value="455,00"/>
        <destination name="Porto Alegre" value="410,00"/>
        <destination name="Recife" value="670,00"/>
        <destination name="Rio de Janeiro" value="0,001"/>
        <destination name="São Paulo" value="99,12"/>
        <destination name="Santos" value="138,82"/>
        <destination name="São Caetano do Sul" value="147,72"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
    <city name="São Paulo">
      <trip_costs>
        <destination name="Belo Horizonte" value="240,00"/>
        <destination name="Campinas" value="114,92"/>
        <destination name="Caxias do Sul" value="350,08"/>
        <destination name="Curitiba" value="289,12"/>
        <destination name="Florianópolis" value="440,00"/>
        <destination name="Fortaleza" value="379,12"/>
        <destination name="Goiânia" value="250"/>
        <destination name="Porto Alegre" value="425"/>
        <destination name="Recife" value="319,12"/>
        <destination name="Rio de Janeiro" value="99,12"/>
        <destination name="São Paulo" value="0,001"/>
        <destination name="Santos" value="39,7"/>
        <destination name="São Caetano do Sul" value="48,6"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
    <city name="Santos">
      <trip_costs>
        <destination name="Belo Horizonte" value="340"/>
        <destination name="Campinas" value="214,92"/>
        <destination name="Caxias do Sul" value="450,08"/>
        <destination name="Curitiba" value="389,12"/>
        <destination name="Florianópolis" value="540,1"/>
        <destination name="Fortaleza" value="479,12"/>
        <destination name="Goiânia" value="350"/>
        <destination name="Porto Alegre" value="525"/>
        <destination name="Recife" value="419,12"/>
        <destination name="Rio de Janeiro" value="199,12"/>
        <destination name="São Paulo" value="100"/>
        <destination name="Santos" value="0,001"/>
        <destination name="São Caetano do Sul" value="88,3"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
    <city name="São Caetano do Sul">
      <trip_costs>
        <destination name="Belo Horizonte" value="290"/>
        <destination name="Campinas" value="164,92"/>
        <destination name="Caxias do Sul" value="400,08"/>
        <destination name="Curitiba" value="339,12"/>
        <destination name="Florianópolis" value="490,02"/>
        <destination name="Fortaleza" value="429,12"/>
        <destination name="Goiânia" value="300"/>
        <destination name="Porto Alegre" value="475"/>
        <destination name="Recife" value="369,12"/>
        <destination name="Rio de Janeiro" value="149,12"/>
        <destination name="São Paulo" value="50"/>
        <destination name="Santos" value="88,3"/>
        <destination name="São Caetano do Sul" value="0,001"/>
      </trip_costs>
      <stay_costs value="120"/>
    </city>
  </cities>
</costs>