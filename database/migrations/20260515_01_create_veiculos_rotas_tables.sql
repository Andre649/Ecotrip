CREATE TABLE public.veiculos (
    id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
    usuario_id UUID REFERENCES auth.users(id) ON DELETE CASCADE,
    marca TEXT,
    modelo TEXT,
    ano INTEGER,
    consumo_medio_cidade NUMERIC,
    consumo_medio_rodovia NUMERIC,
    tipo_combustivel_padrao TEXT
);

CREATE TABLE public.rotas_favoritas (
    id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
    usuario_id UUID REFERENCES auth.users(id) ON DELETE CASCADE,
    nome_da_rota TEXT,
    cidade_origem TEXT,
    cidade_destino TEXT,
    distancia_estimada_km NUMERIC
);

CREATE INDEX idx_veiculos_usuario_id ON public.veiculos(usuario_id);
CREATE INDEX idx_rotas_favoritas_usuario_id ON public.rotas_favoritas(usuario_id);
